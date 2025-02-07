using System;
using System.Collections.Generic;
using SafeHaven.Model;

namespace SafeHaven.View;

public class ConsoleUI
{

    /// <summary>
    /// The title of the application.
    /// </summary>
    private const string Title = "SafeHaven - Protecting Your Home and Family";

    public void PrintMenu(List<MenuItem> menuItems)
    {
        DisplayTitle();

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

    private void DisplayTitle()
    {
        DisplayMessage(Title);
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
