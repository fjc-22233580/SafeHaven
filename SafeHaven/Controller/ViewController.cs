using System;
using System.Collections.Generic;
using SafeHaven.Model;
using SafeHaven.Model.Devices;
using SafeHaven.View;

namespace SafeHaven.Controller;

/// <summary>
/// The view controller for the SafeHaven application.
/// </summary>
public class ViewController
{

    #region Fields

    /// <summary>
    /// The model for the SafeHaven application.
    /// </summary>
    private readonly SafeHavenModel model;

    /// <summary>
    /// The console user interface for the SafeHaven application.
    /// </summary>
    private readonly ConsoleUI consoleUI = new ConsoleUI();

    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="ViewController"/> class.
    /// </summary>
    /// <param name="model"></param>
    public ViewController(SafeHavenModel model)
    {
        this.model = model;

        SubscribeToDeviceEvents();
        CreateMainMenu();
        DisplayMainMenu();
    }

    #endregion

    #region Properties
    /// <summary>
    /// Gets the main menu items for the SafeHaven application.
    /// </summary>
    public List<MenuItem> MainMenu { get; private set; }

    #endregion

    #region Methods

    /// <summary>
    /// Creates the main menu for the SafeHaven application.
    /// </summary>
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

    /// <summary>
    /// Displays the main menu for the SafeHaven application.
    /// </summary>
    private void DisplayMainMenu()
    {
        consoleUI.PrintMenu(MainMenu);
    }

    /// <summary>
    /// Adds a device to the SafeHaven application.
    /// </summary>
    private void AddDevice()
    {
        // Display a message to the user to enter the name of the device and the type.
        consoleUI.DisplayMessage("Enter the name of the device, the type, seperated by a comma.");

        // Get the user input from the console.
        string input = consoleUI.GetInput();

        // Validate the user input.
        if (Validator.ValidateDevice(input))
        {
            // Split the user input into the device name and type.
            string[] deviceInfo = input.Split(',');
            string friendlyName = deviceInfo[0];
            DeviceType deviceType = Enum.Parse<DeviceType>(deviceInfo[1]);
            model.AddDevice(friendlyName, deviceType);

            consoleUI.DisplayMessage("Device added successfully.");
            consoleUI.DisplayMessage("Press any key to return to the main menu.");
            consoleUI.GetInput();
            DisplayMainMenu();
        }
        else
        {
            // Display an error message to the user, and prompt them to try again.
            consoleUI.DisplayMessage("Invalid input. Please try again, or press X to return to the main menu.");
            string userChoice = consoleUI.GetInput();
            if (userChoice.ToLower() == "x")
            {
                DisplayMainMenu();
            }
            else
            {
                AddDevice();
            }
        }
    }

    /// <summary>
    /// Removes a device from the SafeHaven application.
    /// </summary>
    private void RemoveDevice()
    {
        // TODO:   Implement this method
    }

    /// <summary>   
    /// Displays the devices in the SafeHaven application.
    /// </summary>
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

    /// <summary>
    /// Exits the SafeHaven application.
    /// </summary>
    private void Exit()
    {
        Environment.Exit(0);
    }

    /// <summary>
    /// Subscribes to the device events.
    /// </summary>
    private void SubscribeToDeviceEvents()
    {
        foreach (var device in model.Devices)
        {
            device.DeviceStateChanged += Device_DeviceStateChanged;
        }
    }
    #endregion

    #region Event Handlers

    /// <summary>
    /// Handles the DeviceStateChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Device_DeviceStateChanged(object? sender, EventArgs e)
    {
        // TODO: Implement this method
    }

    #endregion
}


// Saharsh was here