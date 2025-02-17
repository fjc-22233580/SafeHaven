using System;

namespace SafeHaven.Model;

/// <summary>
/// Represents a menu item.
/// </summary>
public class MenuItem
{
    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuItem"/> class.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="action"></param>
    public MenuItem(string text, Action action)
    {
        Text = text;
        Action = action;
    }

    #endregion

    #region Properties

    /// <summary>
    /// The text of the menu item.
    /// </summary>
    public string Text { get; }

    /// <summary>
    /// The action to be performed when the menu item is selected.
    /// </summary>
    public Action Action { get; }

    #endregion
}
