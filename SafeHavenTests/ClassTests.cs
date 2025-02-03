using SafeHaven;
using SafeHaven.Devices;
using SafeHaven.Interfaces;
namespace SafeHavenTests;

[TestClass]
public sealed class ClassTests
{
    /// <summary>
    /// Test the creation of the SafeHaven class
    /// </summary>
    [TestMethod]
    public void CreateSafeHavenClassTest()
    {
        // Arrange
        string expectedTitle = "SafeHaven";

        // Act
        Safehaven safehaven = new Safehaven();
        string title = safehaven.Title;

        // Assert
        Assert.AreEqual(expectedTitle, title);
    }

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

        // Act
        IDevice device = DeviceFactory.CreateDevice("Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected);

        DeviceType dexpectedDevice = device.DeviceType;
        string friendlyName = device.FriendlyName;
        DeviceStatus deviceStatus = device.DeviceStatus;

        // Assert
        Assert.AreEqual(expectedDevice, dexpectedDevice);
        Assert.AreEqual(expectedFriendlyName, friendlyName);
        Assert.AreEqual(expectedDeviceStatus, deviceStatus);
    }
}
