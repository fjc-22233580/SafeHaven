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
    public static bool ValidateDevice(string input)
    {
        // Assume invalid device
        bool isValid = false;

        string[] deviceInfo = input.Split(',');
        if (deviceInfo.Length == 2)
        {
            isValid = true;
        }

        return isValid;
    }
}
