using System;
using System.Collections.Generic;
using System.Linq;
using SafeHaven.Model.Devices;
using SafeHaven.Model.Interfaces;

namespace SafeHaven.Model;

/// <summary>   
/// Provides validation services to the SafeHaven app.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Validates the user's menu choice, by checking if its withing the number of menu choies
    /// </summary>
    /// <param name="input">The string the user inputted</param>
    /// <param name="listCount">The count of menu items.</param>
    /// <returns></returns>
    public static int ValidateMenuChoice(string input, int listCount)
    {
        // Assume invalid choice
        int validChoice = -1;

        if (int.TryParse(input, out int choice) && choice > 0 && choice <= listCount)
        {
            validChoice = choice;
        }
        return validChoice;
    }


    /// <summary>
    /// Validates the user's device input to ensure it follows the correct format:
    /// "Device Name,DeviceType". Also checks if the device already exists in the list.
    /// </summary>
    /// <param name="input">The user-provided input string containing the device name and type.</param>
    /// <param name="existingDevices">A list of existing devices to check for duplicates.</param>
    /// <returns>True if the input is valid; otherwise, false.</returns>
    public static bool ValidateDevice(string input, List<IDevice> existingDevices)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        // Split the input by comma to extract the device name and type
        string[] deviceInfo = input.Split(',');

        // Ensure exactly two values are provided: [Device Name, Device Type]
        if (deviceInfo.Length != 2)
        {
            return false;
        }
        // Trim whitespace from the extracted values
        string friendlyName = deviceInfo[0].Trim();
        string deviceTypeString = deviceInfo[1].Trim();

        if (string.IsNullOrWhiteSpace(friendlyName) || string.IsNullOrWhiteSpace(deviceTypeString))
        {
            return false;
        }

        // Check if a device with the same friendly name already exists (case-insensitive)
        if (existingDevices.Any(d => d.FriendlyName.Equals(friendlyName, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        // Validate device type
        return Enum.TryParse<DeviceType>(deviceTypeString, true, out _);
    }

}
