using Godot;
using System;

/// <summary>
/// Setting up the controls menu functionality
/// </summary>
public partial class ControlsMenu : Control
{
    /// <summary>
    /// Reference to the Pause Menu
    /// </summary>
    private PauseMenu pause;

    /// <summary>
    /// Keeps track of whether the game is currently paused or not
    /// </summary>
    bool paused = false;

    /// <summary>
    /// Runs when the "Return" button is pressed. Changes scene back to Main Menu.
    /// </summary>
    public void _on_return_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/menu.tscn");
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("pause"))
        {
            pauseMenu();
        }
    }

    /// <summary>
    /// Toggles the pause menu. Freezes time if selected, unfreezes if not.
    /// </summary>
    public void pauseMenu()
    {
        if (paused)
        {
            pause.Hide();
            Engine.TimeScale = 1;
        }
        else
        {
            pause.Show();
            Engine.TimeScale = 0;
        }
        paused = !paused;
    }
}