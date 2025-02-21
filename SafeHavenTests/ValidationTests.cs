using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;
using SafeHaven.Model;

namespace SafeHavenTests;

/// <summary>
/// Validation unit tests.
/// </summary>
[TestClass]
public class ValidationTests
{
    /// <summary>
    /// The list of existing devices.
    /// </summary>
    private List<IDevice> existingDevices;

    /// <summary>
    /// Setup the test.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        // Create a sample list of existing devices
        existingDevices = new List<IDevice>
        {
            new FireDetector(Guid.NewGuid(), "Kitchen Fire Detector", DeviceType.FireDetector)
        };
    }

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

    /// <summary>
    /// Tests if ValidateDevice accepts a valid input.
    /// </summary>
    [TestMethod]
    public void TestValidDeviceValidation()
    {
        // Arrange
        string validFireDetector = "Living Room Detector,FireDetector";
        string validMotionDetector = "BedRoom Detector,MotionDetector";

        // Act
        bool isValidFireDetector = Validator.ValidateDevice(validFireDetector, existingDevices);
        bool isValidMotionDetector = Validator.ValidateDevice(validMotionDetector, existingDevices);

        // Assert
        Assert.IsTrue(isValidFireDetector, "Expected valid input to return true.");
        Assert.IsTrue(isValidMotionDetector, "Expected valid input to return true.");
    }

    /// <summary>
    /// Tests if ValidateDevice rejects input with incorrect values.
    /// </summary>
    [TestMethod]
    public void TestInvalidDeviceValidation()
    {
        // Arrange
        string missingDeviceType = "Living Room Detector,";
        string missingDeviceName = ",FireDetector";
        string emptyInput = " ";
        string extraValues = "Living Room Detector,FireDetector,Extra";
        string invalidDeviceType = "Living Room Detector,InvalidType";
        string duplicateDevice = "Kitchen Fire Detector,FireDetector";

        // Act
        bool deviceIsMissing = Validator.ValidateDevice(missingDeviceType, existingDevices);
        bool nameIsMissing = Validator.ValidateDevice(missingDeviceName, existingDevices);
        bool inputIsEmpty = Validator.ValidateDevice(emptyInput, existingDevices);
        bool tooManyValues = Validator.ValidateDevice(extraValues, existingDevices);
        bool invalidType = Validator.ValidateDevice(invalidDeviceType, existingDevices);
        bool isDuplicate = Validator.ValidateDevice(duplicateDevice, existingDevices);

        // Assert
        Assert.IsFalse(deviceIsMissing, "Expected input missing device type to return false.");
        Assert.IsFalse(nameIsMissing, "Expected input missing device name to return false.");
        Assert.IsFalse(inputIsEmpty, "Expected empty input to return false.");
        Assert.IsFalse(tooManyValues, "Expected input with extra values to return false.");
        Assert.IsFalse(invalidType, "Expected input with an invalid device type to return false.");
        Assert.IsFalse(isDuplicate, "Expected input with a duplicate device to return false.");
    }
}