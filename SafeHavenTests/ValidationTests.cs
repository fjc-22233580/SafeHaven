using System;
using SafeHaven.Model;

namespace SafeHavenTests;

/// <summary>
/// Validation unit tests.
/// </summary>
[TestClass]
public class ValidationTests
{
    /// <summary>
    /// Test the menu choice validation.
    /// </summary>
    [TestMethod]
    public void TestMenuChoiceValidation()
    {
        // Arrange
        int expected = 1;
        int listCount = 3;
        string validNumericalInput = "1";
        string invalidNumericalInput = "4";
        string invalidNonNumericalInput = "a";

        // Act
        int goodOutput = Validator.ValidateMenuChoice(validNumericalInput, listCount);
        int invalidNumericalOutput = Validator.ValidateMenuChoice(invalidNumericalInput, listCount);
        int invalidNonNumericalOutput = Validator.ValidateMenuChoice(invalidNonNumericalInput, listCount);

        // Assert
        Assert.AreEqual(expected, goodOutput, "The menu choice validation failed.");
        Assert.AreEqual(-1, invalidNumericalOutput, "The menu choice validation failed.");
        Assert.AreEqual(-1, invalidNonNumericalOutput, "The menu choice validation failed.");
    }
}
