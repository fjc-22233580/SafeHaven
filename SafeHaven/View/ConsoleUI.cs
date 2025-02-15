using System;
using System.Collections.Generic;
using SafeHaven.Model;

namespace SafeHaven.View;

/// <summary>
/// The console user interface for the SafeHaven application.
/// </summary>
public class ConsoleUI
{
    #region Constants

    /// <summary>
    /// The title of the application.
    /// </summary>
    private const string Title = "SafeHaven - Protecting Your Home and Family";

    #endregion

    #region Methods

    /// <summary>
    /// Prints the main menu to the console.
    /// </summary>
    /// <param name="menuItems"></param>
    public void PrintMenu(List<MenuItem> menuItems)
    {
        Clear();
        foreach (var menuItem in menuItems)
        {
            Console.WriteLine(menuItem.Text);
        }

        // Get user input from the console.
        string input = GetInput();

        // Validate the user's input.
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

    /// <summary>
    /// Displays a message to the console.
    /// </summary>
    /// <param name="message"></param>
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Displays the title of the application.
    /// </summary>
    private void DisplayTitle()
    {
        DisplayMessage(Title);
    }

    /// <summary>   
    /// Gets input from the console.
    /// </summary>
    public string GetInput()
    {
        return Console.ReadLine();
    }

    /// <summary>
    /// Clears the console screen, and displays the title.
    /// </summary>
    public void Clear()
    {
        Console.Clear();
        DisplayTitle();
    }

    #endregion
}
