using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

namespace SafeHavenTests;

/// <summary>
/// Unit tests for the classes in the SafeHaven project.
/// </summary>
[TestClass]
public sealed class ClassTests
{
    /// <summary>
    /// Test the creation of the the IDevice factory
    /// </summary>
    [TestMethod]
    public void TestDeviceFactory()
    {
        // Arrange
        DeviceType expectedDevice = DeviceType.FireDetector;
        string expectedFriendlyName = "Fire Detector";
        DeviceStatus expectedDeviceStatus = DeviceStatus.Connected;

        DeviceType expectedDevice = DeviceType.MotionDectector;
        string expectedFriendlyName = "Motion Detector";
        DeviceStatus expectedDeviceStatus = DeviceStatus.Connected;

        // Act
        IDevice device = DeviceFactory.CreateDevice("Fire Detector", DeviceType.FireDetector);
        IDevice device = DeviceFactory.CreateDevice("Motion Detector", DeviceType.MotionDetector);

        DeviceType dexpectedDevice = device.DeviceType;
        string friendlyName = device.FriendlyName;
        DeviceStatus deviceStatus = device.DeviceStatus;

        // Assert
        Assert.AreEqual(expectedDevice, dexpectedDevice);
        Assert.AreEqual(expectedFriendlyName, friendlyName);
        Assert.AreEqual(expectedDeviceStatus, deviceStatus);
    }
}
