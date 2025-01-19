using SafeHaven;
namespace SafeHavenTests;

[TestClass]
public sealed class ClassTests
{
    [TestMethod]
    public void CreateSafeHavenClassTest()
    {      
        // Arrange
        Safehaven safehaven = new Safehaven();

        // Act
        string expectedTitle = "SafeHaven";
        string title = safehaven.Title;

        // Assert
        Assert.AreEqual(expectedTitle, title);
    }
}
