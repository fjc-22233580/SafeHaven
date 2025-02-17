using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;
using System.Collections.Generic;
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

    private List<IDevice> existingDevices;

    [TestInitialize]
    public void Setup()
    {
        // Create a sample list of existing devices
        existingDevices = new List<IDevice>
            {
                new FireDetector(System.Guid.NewGuid(), "Kitchen Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected)
            };
    }

    /// <summary>
    /// Tests if ValidateDevice accepts a valid input.
    /// </summary>
    [TestMethod]
    public void ValidateValidDevice()
    {
        bool result = Validator.ValidateDevice("Living Room Detector,FireDetector", existingDevices);
        Assert.IsTrue(result, "Expected valid input to return true.");
    }

    /// <summary>
    /// Tests if ValidateDevice rejects input with missing values.
    /// </summary>
    [TestMethod]
    public void RejectsMissingValues()
    {
        bool result1 = Validator.ValidateDevice("Living Room Detector,", existingDevices);
        bool result2 = Validator.ValidateDevice(",FireDetector", existingDevices);
        bool result3 = Validator.ValidateDevice(" ", existingDevices);

        Assert.IsFalse(result1, "Expected input missing device type to return false.");
        Assert.IsFalse(result2, "Expected input missing device name to return false.");
        Assert.IsFalse(result3, "Expected empty input to return false.");
    }

    /// <summary>
    /// Tests if ValidateDevice rejects input with too many values.
    /// </summary>
    [TestMethod]
    public void RejectsExtraValues()
    {
        bool result = Validator.ValidateDevice("Living Room Detector,FireDetector,Extra", existingDevices);
        Assert.IsFalse(result, "Expected input with extra values to return false.");
    }

    /// <summary>
    /// Tests if ValidateDevice rejects an invalid device type.
    /// </summary>
    [TestMethod]
    public void RejectsInvalidDeviceType()
    {
        bool result = Validator.ValidateDevice("Living Room Detector,InvalidType", existingDevices);
        Assert.IsFalse(result, "Expected input with an invalid device type to return false.");
    }

    /// <summary>
    /// Tests if ValidateDevice rejects duplicate device names.
    /// </summary>
    [TestMethod]
    public void RejectsDuplicateDevice()
    {
        bool result = Validator.ValidateDevice("Kitchen Fire Detector,FireDetector", existingDevices);
        Assert.IsFalse(result, "Expected duplicate device name to return false.");
    }