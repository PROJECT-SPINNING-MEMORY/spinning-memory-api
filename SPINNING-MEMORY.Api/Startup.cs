using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPINNING_MEMORY.Data;
using SPINNING_MEMORY.Data.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace SPINNING_MEMORY.Api
{
    public class Startup
    {
        private readonly string _auth0Domain;
        private readonly string _auth0Audience;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _auth0Domain = Configuration["Auth0:Authority"];
            _auth0Audience = Configuration["Auth0:Audience"];
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Auth0 Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = _auth0Domain;
                options.Audience = _auth0Audience;
            });

            // Authorization policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("delete:catalog", policy =>
                    policy.Requirements.Add(new HasScopeRequirement("delete:catalog", _auth0Domain)));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            // CORRECT DB CONTEXT
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite("Data Source=/Users/chloeporter/spinning-memory-api-4/Registrar.sqlite",
                    b => b.MigrationsAssembly("SPINNING-MEMORY.Data")));



            // CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SPINNING_MEMORY.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
