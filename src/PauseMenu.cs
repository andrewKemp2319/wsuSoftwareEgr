using System;
using Godot;

/// <summary>
/// Setting up the functionality to pause game with a pause menu
/// </summary>
public partial class PauseMenu : Control
{
    /// <summary>
    /// A reference to the Main Menu
    /// </summary>
    private MainMenu main;
    /// <summary>
    /// Reference to a popup window displaying the controls menu
    /// </summary>
    private Window pop;

    public override void _Ready()
    {
        main = GetParent<MainMenu>();
        pop = GetNode<Window>("ControlsPop");
        GD.Print(pop.Name);
    }

    /// <summary>
    /// Runs when the "Resume" button is pressed. Toggles this menu
    /// </summary>
    public void _on_resume_pressed()
    {
        main.pauseMenu();
    }

    /// <summary>
    /// Runs when the "Controls" button is pressed. Enables the popup window.
    /// </summary>
    public void _on_controls_pressed()
    {
        pop.Show();
    }

    /// <summary>
    /// Runs when the popup "X" is pressed. Disables the popup window.
    /// </summary>
    public void _on_controls_pop_close_requested()
    {
        pop.Hide();
    }

    /// <summary>
    /// Runs when the "quit" button is pressed. Closes the game.
    /// </summary>
    public void _on_quit_pressed()
    {
        GetTree().Quit();
    }

}