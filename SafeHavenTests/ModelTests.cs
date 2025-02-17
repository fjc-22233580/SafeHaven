using SafeHaven.Model;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

namespace SafeHavenTests;

[TestClass]
public class ModelTests
{

    /// <summary>
    /// Tests the menu creation.
    /// </summary>
    [TestMethod]
    public void TestMenuItemCreation()
    {
        // Arrange
        string expectedName = "Test";
        Action expectedAction = () => { Console.WriteLine("Test"); };

        // Act
        MenuItem menuItem = new MenuItem(expectedName, expectedAction);

        // Assert
        Assert.AreEqual(expectedName, menuItem.Text, "The menu item name was not set correctly.");
        Assert.AreEqual(expectedAction, menuItem.Action, "The menu item action was not set correctly.");
    }

    /// <summary>
    /// Tests the model creation and adding devices.
    /// </summary>
    [TestMethod]
    public void TestModel()
    {
        // Arrange
        IDevice device = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector);

        // Act
        SafeHavenModel model = new SafeHavenModel();
        model.AddDevice("Fire Detector", DeviceType.FireDetector);
        bool deviceAdded = model.Devices.FirstOrDefault(d => d.FriendlyName == "Fire Detector") != null;

        // Assert
        Assert.IsNotNull(model.Devices, "The devices list was not created.");
        Assert.IsTrue(deviceAdded, "The device was not added to the list.");
    }

    /// <summary>
    /// Tests the device manager.
    /// </summary>
    [TestMethod]
    public void TestDeviceManager()
    {
        // Arrange
        FireDetector device = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector)
        {
            IsSmokeDetected = true,
            Temperature = 100
        };
        DeviceManager deviceManager = new DeviceManager();

        // Act
        deviceManager.AddDevice(device);
        bool deviceAdded = deviceManager.Devices.FirstOrDefault(d => d.FriendlyName == "Fire Detector") != null;
        deviceManager.CheckDevices();
        bool isFireAlarmTriggered = deviceManager.CanSoundFireAlarm;

        // Assert
        Assert.IsNotNull(deviceManager.Devices, "The devices list was not created.");
        Assert.IsTrue(deviceAdded, "The device was not added to the list.");
        Assert.IsTrue(isFireAlarmTriggered, "The fire alarm was not triggered.");
    }
}
