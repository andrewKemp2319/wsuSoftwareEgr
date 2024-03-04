using Godot;
using System;
using System.IO;

/// <summary>
/// setting up the physics and damage of the weapons
/// </summary>
public partial class Weapon : Node2D
{
	[Export]
	/// <summary> Stats of this weapon </summary>
	protected int damage = 2;

	/// <summary> Can this weapon attack if input is received? </summary>
	private bool canAttack = true;
	/// <summary> Is the player currently using this weapon? </summary>
	private bool inUse = true;

	/// <summary>
	/// Protected so child classes can get them.
	/// </summary>
	protected Node2D pivot;
	/// <summary>
	/// Reference to timer object to track cooldown.
	/// </summary>
	private Timer timer;
	/// <summary>
	/// Reference to audioplayer to play sound effects.
	/// </summary>
	private AudioStreamPlayer2D audio;


	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
		pivot = GetParent<Node2D>();
		audio = GetNode<AudioStreamPlayer2D>("SFX");
		timer = GetNode<Timer>("weaponTimer");
	}

    /// <summary>
	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	/// </summary>
	/// <param name="delta"></param>
    public override void _PhysicsProcess(double delta)
    {
		if(!inUse)
		{
			return;
		}
		
		/// Handle weapon pivot
        if (pivot.GlobalRotationDegrees > 90 || pivot.GlobalRotationDegrees < -90)
        {
            pivot.Scale = new Vector2(pivot.Scale.X, -1);
        }
        else
        {
            pivot.Scale = new Vector2(pivot.Scale.X, 1);
        }
        pivot.LookAt(GetGlobalMousePosition());

		if(Input.IsActionJustPressed("use_weapon") && canAttack)
		{
			useWeapon();
			timer.Start();
			audio.Play();
			canAttack = false;
		}
    }

	public void setUse(bool b)
	{	
		inUse = b;	
		/// Reset pivot if set to true
		if(b)
		{
			timer.Start();
			pivot = GetParent<Node2D>();
		}
		else
		{
			timer.Stop();
		}
	}

	/// <summary>
	/// Run when the timer hits 0. Allows this weapon to be used again.
	/// </summary>
    private void _on_weapon_timer_timeout()
	{
		onTimer();
		canAttack = true;
	}

	/// <summary>
	/// Something for weapons to adjust after timeout
	/// </summary>
	public virtual void onTimer()
	{}

	/// <summary>
	/// Something for derived classes to use
	/// </summary>
	public virtual void useWeapon()
	{}
}
