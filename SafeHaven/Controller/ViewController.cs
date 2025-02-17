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
    public ViewController()
    {
        model = new SafeHavenModel();
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
        consoleUI.Clear();
        // Display a message to the user to enter the name of the device and the type.
        consoleUI.DisplayMessage("Enter the name of the device, the type, seperated by a comma.");

        // Get the user input from the console.
        string input = consoleUI.GetInput();

        // Validate the user input.
        if (Validator.ValidateDevice(input, model.Devices))
        {
            // Split the user input into the device name and type.
            string[] deviceInfo = input.Split(',');
            string friendlyName = deviceInfo[0];
            DeviceType deviceType = Enum.Parse<DeviceType>(deviceInfo[1]);
            model.AddDevice(friendlyName, deviceType);

            consoleUI.DisplayMessage("Device added successfully.");
            ReturnToMainMenu();
        }
        else
        {
            // Display an error message to the user, and prompt them to try again.
            consoleUI.DisplayMessage("Invalid input. Press enter to try again, or press X to return to the main menu.");
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
        // Show options
        consoleUI.Clear();
        PrintDevices();
        consoleUI.DisplayMessage("Enter the number of the device you would like to remove.");

        // Get the user input from the console.
        string input = consoleUI.GetInput();
        int deviceNumber = Validator.ValidateMenuChoice(input, model.Devices.Count);
        if (deviceNumber != -1)
        {
            // Ask user to confirm removal
            consoleUI.DisplayMessage("Are you sure you wish to remove this device? (Y/N)");
            string userChoice = consoleUI.GetInput();
            if (userChoice.ToLower() == "y")
            {
                model.Devices.RemoveAt(deviceNumber - 1);
                consoleUI.DisplayMessage("Device removed successfully.");
                ReturnToMainMenu();
            }
            else
            {
                consoleUI.DisplayMessage("Device not removed.");
                ReturnToMainMenu();
            }

        }
        else
        {
            consoleUI.DisplayMessage("Invalid input.");
            ReturnToMainMenu();
        }
    }

    /// <summary>   
    /// Displays the devices in the SafeHaven application.
    /// </summary>
    private void DisplayDevices()
    {
        consoleUI.Clear();
        PrintDevices();
        ReturnToMainMenu();
    }

    /// <summary>
    /// Returns the user to the main menu.
    /// </summary>
    private void ReturnToMainMenu()
    {
        consoleUI.DisplayMessage("Press any key to return to the main menu.");
        consoleUI.GetInput();
        DisplayMainMenu();
    }

    /// <summary>
    /// Prints the devices in the SafeHaven application.
    /// </summary>
    private void PrintDevices()
    {
        int ordinal = 1;
        foreach (var device in model.Devices)
        {
            string deviceSummary = $"{ordinal}: Device: {device.FriendlyName}, Type: {device.DeviceType}, Status: {device.DeviceStatus}";
            consoleUI.DisplayMessage(deviceSummary);
            ordinal++;
        }
    }

    /// <summary>
    /// Exits the SafeHaven application.
    /// </summary>
    private void Exit()
    {
        Environment.Exit(0);
    }
    #endregion
}