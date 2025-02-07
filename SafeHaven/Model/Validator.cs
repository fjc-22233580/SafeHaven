using System;

namespace SafeHaven.Model;

public static class Validator
{
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
}
