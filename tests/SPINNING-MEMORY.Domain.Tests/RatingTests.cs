using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPINNING_MEMORY.Domain;
using SPINNING_MEMORY.Domain.Catalog;

namespace SPINNING_MEMORY.Domain.Tests;  //folder name (tests/SPINNING-MEMORY.Domain.Tests)

[TestClass]
public sealed class RatingTests //Match filename 
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        // Arrange
        var rating = new Rating(1, "Mike", "Great fit!");

        // Act (empty)

        // Assert
        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Rating_With_Invalid_Stars()
    {
        // Arrange
        var rating = new Rating(0, "Mike", "Great fit!");
    }
}
