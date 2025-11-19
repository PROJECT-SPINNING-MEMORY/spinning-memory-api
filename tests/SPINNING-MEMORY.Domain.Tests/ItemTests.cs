using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPINNING_MEMORY.Domain;
using SPINNING_MEMORY.Domain.Catalog;

namespace SPINNING_MEMORY.Domain.Tests;  //folder name (tests/SPINNING-MEMORY.Domain.Tests)

[TestClass]
public sealed class ItemTests //Match filename 
{
    [TestMethod]
    public void Can_Create_New_Item()
    {
        //Arrange

        var item = new Item("Name", "Description", "Brand", 10.00m);

        //Assert

        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }
    
    [TestMethod]
    public void Can_Create_Add_Rating()
    {
        
        //Arrange
        var item = new Item("Name", "Description", "Brand", 10.00m);
        var rating = new Rating(5, "Name", "Review");

        //Act

        item.AddRating(rating); //Pass rating object above

        //Assert

        Assert.AreEqual(rating, item.Ratings[0]);
    }
}
