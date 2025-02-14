using System;

namespace SafeHaven.Model;

/// <summary>   
/// Provides validation services to the SafeHaven app.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Validates the user's menu choice.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="listCount"></param>
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
    /// Validates the user's device input.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>

    using System.Linq;

public static bool ValidateDevice(string input, List<IDevice> existingDevices)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        return false;
    }

    string[] deviceInfo = input.Split(',');

    if (deviceInfo.Length != 2)
    {
        return false;
    }

    string friendlyName = deviceInfo[0].Trim();
    string deviceTypeString = deviceInfo[1].Trim();

    if (string.IsNullOrWhiteSpace(friendlyName) || string.IsNullOrWhiteSpace(deviceTypeString))
    {
        return false;
    }

    // Check if the device already exists
    if (existingDevices.Any(d => d.FriendlyName.Equals(friendlyName, StringComparison.OrdinalIgnoreCase)))
    {
        return false;
    }

    // Validate device type
    return Enum.TryParse<DeviceType>(deviceTypeString, true, out _);
}

}
