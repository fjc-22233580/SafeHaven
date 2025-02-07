using System;
using System.Collections.Generic;
using SafeHaven.Model;

namespace SafeHaven.View;

public class ConsoleUI
{
    public void PrintMenu(List<MenuItem> menuItems)
    {
        foreach (var menuItem in menuItems)
        {
            Console.WriteLine(menuItem.Text);
        }

        // Get user input from the console.
        string input = GetInput();

        int menuChoice = Validator.ValidateMenuChoice(input, menuItems.Count);
        if (menuChoice != -1)
        {
            menuItems[menuChoice - 1].Action();
        }
        else
        {
            DisplayMessage("Invalid input. Please try again.");
            PrintMenu(menuItems);
        }
    }


    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }

    public void Clear()
    {
        Console.Clear();
    }
}
