using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

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
        FireDetector expectedFireDetector = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected);
        MotionDetector expectedMotionDetector = new MotionDetector(Guid.NewGuid(), "Motion Detector", DeviceType.MotionDetector, DeviceStatus.Connected);

        // Act
        IDevice createdFireDetector = DeviceFactory.CreateDevice("Fire Detector", DeviceType.FireDetector);
        IDevice createdMotionDetector = DeviceFactory.CreateDevice("Motion Detector", DeviceType.MotionDetector);

        // Assert
        Assert.AreEqual(expectedFireDetector.FriendlyName, createdFireDetector.FriendlyName, "The friendly name of the created fire detector does not match the expected value.");
        Assert.AreEqual(expectedFireDetector.DeviceType, createdFireDetector.DeviceType, "The device type of the created fire detector does not match the expected value.");
        Assert.AreEqual(expectedMotionDetector.FriendlyName, createdMotionDetector.FriendlyName, "The friendly name of the created motion detector does not match the expected value.");
        Assert.AreEqual(expectedMotionDetector.DeviceType, createdMotionDetector.DeviceType, "The device type of the created motion detector does not match the expected value.");
    }

    /// <summary>
    /// Test the creation the motion detector class
    /// </summary>
    [TestMethod]
    public void TestFireDetectorCreation()
    {
        DeviceType expectedDeviceType = DeviceType.FireDetector;
        string expectedFriendlyName = "Fire Detector";
        DeviceStatus expectedDeviceStatus = DeviceStatus.Connected;

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
        DeviceStatus expectedDeviceStatus = DeviceStatus.Connected;

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
    /// Test the fire detector class for fire detection.
    /// </summary>
    [TestMethod]
    public void TestFireDetection()
    {
        // Arrange
        FireDetector fireDetector = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected);
        fireDetector.IsSmokeDetected = true;
        fireDetector.Temperature = 60;

        // Act
        bool isFireDetected = fireDetector.IsFireDetected;

        // Assert
        Assert.IsTrue(isFireDetected, "The fire detector did not detect the fire.");
    }

}
