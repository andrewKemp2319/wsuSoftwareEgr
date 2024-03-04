using Godot;
using System;

/// <summary>
/// Setting up the functionality of the main menu
/// </summary>
public partial class MainMenu : Control
{
    /// <summary>
    /// A reference to the Pause Menu
    /// </summary>
    private PauseMenu pause;
    /// <summary>
    /// Keeps track of whether the game is currently paused or not
    /// </summary>
    private bool paused = false;

    public override void _Ready()
    {
        pause = GetNode<PauseMenu>("Pause");
    }

    /// <summary>
    /// Runs when the "Start" button is pressed. Loads the TestLevel
    /// </summary>
    public void _on_start_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/testlevel.tscn");
    }

    /// <summary>
    /// Runs when the "Controls" button is pressed. Loads the Controls Menu
    /// </summary>
    public void _on_controls_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/controls.tscn");
    }

    /// <summary>
    /// Runs when the "Exit" button is pressed. Closes the game
    /// </summary>
    public void _on_exit_pressed()
    {
        GetTree().Quit();
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
            Engine.TimeScale = 1;
        }
        else
        {
            Engine.TimeScale = 0;
        }
        pause.Visible = paused;
        paused = !paused;
    }
}