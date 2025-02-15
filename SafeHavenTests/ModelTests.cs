using System;
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

    [TestMethod]
    public void TestModel()
    {
        // Arrange
        IDevice device = new FireDetector(Guid.NewGuid(), "Fire Detector", DeviceType.FireDetector, DeviceStatus.Connected);

        // Act
        SafeHavenModel model = new SafeHavenModel();
        List<IDevice> devices = model.Devices;
        model.AddDevice("Fire Detector", DeviceType.FireDetector);

        // Assert
        Assert.IsNotNull(devices, "The devices list was not created.");
        Assert.AreEqual(1, devices.Count, "The device was not added to the list.");
        Assert.AreEqual(device.FriendlyName, devices[0].FriendlyName, "A different device was added to the list.");
    }   
}
