using System;
using System.Collections.Generic;
using SafeHaven.Model;
using SafeHaven.View;

namespace SafeHaven.Controller;

public class ViewController
{

    #region Fields

    private readonly SafeHavenModel model;

    private readonly ConsoleUI consoleUI = new ConsoleUI();

    #endregion
    public ViewController(SafeHavenModel model)
    {
        this.model = model;

        SubscribeToDeviceEvents();
        CreateMainMenu();
        DisplayMainMenu();
    }

    public List<MenuItem> MainMenu { get; private set; }

    private void CreateMainMenu()
    {
        MainMenu = new List<MenuItem>
        {
            new MenuItem("1. Add Device", AddDevice),
            new MenuItem("2. Remove Device", RemoveDevice),
            new MenuItem("3. Display Devices", DisplayDevices),
            new MenuItem("4. Exit", Exit)
        };
    }

    private void DisplayMainMenu()
    {
        consoleUI.PrintMenu(MainMenu);
    }

    private void AddDevice()
    {
        // TODO:   Implement this method
    }

    private void RemoveDevice()
    {
        // TODO:   Implement this method
    }

    private void DisplayDevices()
    {
        foreach (var device in model.Devices)
        {
            string deviceSummary = $"Device: {device.FriendlyName}, Type: {device.DeviceType}, Status: {device.DeviceStatus}";
            consoleUI.DisplayMessage(deviceSummary);
        }
        
        consoleUI.DisplayMessage("Press any key to return to the main menu.");
        consoleUI.GetInput();
        DisplayMainMenu();
    }

    private void Exit()
    {
        Environment.Exit(0);
    }

    private void SubscribeToDeviceEvents()
    {
        foreach (var device in model.Devices)
        {
            device.DeviceStateChanged += Device_DeviceStateChanged;
        }
    }

    private void Device_DeviceStateChanged(object? sender, EventArgs e)
    {
        // TODO: Implement this method
    }
}
