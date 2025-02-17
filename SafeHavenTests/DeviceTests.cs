using SafeHaven.Model;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace SafeHavenTests;

/// <summary>
/// Unit tests for the classes in the SafeHaven project.
/// </summary>
[TestClass]
public class DeviceTests
{
    /// <summary>
    /// Test the creation of the the IDevice factory
    /// </summary>
    [TestMethod]
    public void TestDeviceFactory()
    {
        // Arrange
        FireDetector expectedFireDetector = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector);
        MotionDetector expectedMotionDetector = new MotionDetector(Guid.NewGuid(), "Motion Detector", DeviceType.MotionDetector);
        WindowDoorSensor expectedWindowDoorSensor = new WindowDoorSensor(Guid.NewGuid(), "Front Door Sensor", DeviceType.WindowDoorSensor);

        // Act
        IDevice createdFireDetector = DeviceFactory.CreateDevice("Fire Detector", DeviceType.FireDetector);
        IDevice createdMotionDetector = DeviceFactory.CreateDevice("Motion Detector", DeviceType.MotionDetector);
        IDevice createdWindowDoorSensor = DeviceFactory.CreateDevice("Front Door Sensor", DeviceType.WindowDoorSensor);
        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => DeviceFactory.CreateDevice("Unknown Device", DeviceType.Unkown));

        // Assert
        Assert.AreEqual(expectedFireDetector.FriendlyName, createdFireDetector.FriendlyName, "The friendly name of the created fire detector does not match the expected value.");
        Assert.AreEqual(expectedFireDetector.DeviceType, createdFireDetector.DeviceType, "The device type of the created fire detector does not match the expected value.");
        Assert.AreEqual(expectedMotionDetector.FriendlyName, createdMotionDetector.FriendlyName, "The friendly name of the created motion detector does not match the expected value.");
        Assert.AreEqual(expectedMotionDetector.DeviceType, createdMotionDetector.DeviceType, "The device type of the created motion detector does not match the expected value.");
        Assert.AreEqual(expectedWindowDoorSensor.FriendlyName, createdWindowDoorSensor.FriendlyName, "The friendly name of the created window door sensor does not match the expected value.");
        Assert.AreEqual(expectedWindowDoorSensor.DeviceType, createdWindowDoorSensor.DeviceType, "The device type of the created window door sensor does not match the expected value.");
        Assert.IsNotNull(exception, "The exception was not thrown when an unknown device type was used.");
    }

    /// <summary>
    /// Test the creation the motion detector class
    /// </summary>
    [TestMethod]
    public void TestFireDetectorCreation()
    {
        DeviceType expectedDeviceType = DeviceType.FireDetector;
        string expectedFriendlyName = "Fire Detector";
        DeviceStatus expectedDeviceStatus = DeviceStatus.Standby;

        // Act
        IDevice device = DeviceFactory.CreateDevice("Fire Detector", DeviceType.FireDetector);
        DeviceType deviceType = device.DeviceType;
        string friendlyName = device.FriendlyName;
        DeviceStatus deviceStatus = device.DeviceStatus;

        // Assert
        Assert.AreEqual(expectedDeviceType, deviceType, "The device type of the created Fire detector does not match the expected value.");
        Assert.AreEqual(expectedFriendlyName, friendlyName, "The friendly name of the created Fire detector does not match the expected value.");
        Assert.AreEqual(expectedDeviceStatus, deviceStatus, "The device status of the created Fire detector does not match the expected value.");
    }

    /// <summary>
    /// Test the creation the motion detector class
    /// </summary>
    [TestMethod]
    public void TestMotionDetectorCreation()
    {
        DeviceType expectedDeviceType = DeviceType.MotionDetector;
        string expectedFriendlyName = "Motion Detector";
        DeviceStatus expectedDeviceStatus = DeviceStatus.Standby;

        // Act
        IDevice device = DeviceFactory.CreateDevice("Motion Detector", DeviceType.MotionDetector);
        DeviceType deviceType = device.DeviceType;
        string friendlyName = device.FriendlyName;
        DeviceStatus deviceStatus = device.DeviceStatus;

        // Assert
        Assert.AreEqual(expectedDeviceType, deviceType, "The device type of the created motion detector does not match the expected value.");
        Assert.AreEqual(expectedFriendlyName, friendlyName, "The friendly name of the created motion detector does not match the expected value.");
        Assert.AreEqual(expectedDeviceStatus, deviceStatus, "The device status of the created motion detector does not match the expected value.");
    }


    /// <summary>
    /// Test the creation the motion detector class
    /// </summary>
    [TestMethod]
    public void TestWindowDoorSensorCreation()
    {
        DeviceType expectedDeviceType = DeviceType.WindowDoorSensor;
        string expectedFriendlyName = "Door Detector";
        DeviceStatus expectedDeviceStatus = DeviceStatus.Standby;

        // Act
        IDevice device = DeviceFactory.CreateDevice("Door Detector", DeviceType.WindowDoorSensor);
        DeviceType deviceType = device.DeviceType;
        string friendlyName = device.FriendlyName;
        DeviceStatus deviceStatus = device.DeviceStatus;

        // Assert
        Assert.AreEqual(expectedDeviceType, deviceType, "The device type of the created window/door sensor does not match the expected value.");
        Assert.AreEqual(expectedFriendlyName, friendlyName, "The friendly name of the created window/door sensor does not match the expected value.");
        Assert.AreEqual(expectedDeviceStatus, deviceStatus, "The device status of the created window/door sensor does not match the expected value.");
    }

    /// <summary>
    /// Test the fire detector class for fire detection.
    /// </summary>
    [TestMethod]
    public void TestFireDetection()
    {
        // Arrange
        FireDetector fireDetector = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector);
        fireDetector.IsSmokeDetected = true;
        fireDetector.Temperature = 60;

        // Act
        bool isFireDetected = fireDetector.DeviceStatus == DeviceStatus.Triggered;

        // Assert
        Assert.IsTrue(isFireDetected, "The fire detector did not detect the fire.");
    }

namespace SafeHavenTests
{
    /// <summary>
    /// Unit tests for the Validator class.
    /// </summary>
    [TestClass]
    public sealed class ValidatorTests
    {
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
        public void validateValidDevice()
        {
            bool result = Validator.ValidateDevice("Living Room Detector,FireDetector", existingDevices);
            Assert.IsTrue(result, "Expected valid input to return true.");
        }

        /// <summary>
        /// Tests if ValidateDevice rejects input with missing values.
        /// </summary>
        [TestMethod]
        public void rejectsMissingValues()
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
        public void rejectsExtraValues()
        {
            bool result = Validator.ValidateDevice("Living Room Detector,FireDetector,Extra", existingDevices);
            Assert.IsFalse(result, "Expected input with extra values to return false.");
        }

        /// <summary>
        /// Tests if ValidateDevice rejects an invalid device type.
        /// </summary>
        [TestMethod]
        public void rejectsInvalidDeviceType()
        {
            bool result = Validator.ValidateDevice("Living Room Detector,InvalidType", existingDevices);
            Assert.IsFalse(result, "Expected input with an invalid device type to return false.");
        }

        /// <summary>
        /// Tests if ValidateDevice rejects duplicate device names.
        /// </summary>
        [TestMethod]
        public void rejectsDuplicateDevice()
        {
            bool result = Validator.ValidateDevice("Kitchen Fire Detector,FireDetector", existingDevices);
            Assert.IsFalse(result, "Expected duplicate device name to return false.");
        }
    }
}
}
