using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Setting up the Enemies stats and functionality
/// </summary>
public partial class EnemyBase : CharacterBody2D
{
	// Enemy stats
	[Export]
	private int healthStat = 2;
	[Export]
	private int strengthStat = 2;
	[Export]
	private float speedStat = 1.5f;

	private HealthComponent health;

	/// <summary>List of all Turret children of the enemy</summary>
	private List<Turret> turrets = new List<Turret>();

	/// <summary>Patterns can be represented as: "pSpeed-type-tSpeed-track-time"</summary>
	[Export]
	private string[] patterns;

	/// <summary> Timer object keeping track of current pattern time </summary>
	private Timer timer;
	/// <summary> AudioPlayer object </summary>
	private AudioStreamPlayer2D audio;
	/// <summary> Array of audio streams the AudioPlayer can play </summary>
	private AudioStream[] streams = new AudioStream[2]; // 0 == Hurt, 1 == Shoot


	/// <summary> The start position of the enemy's movement </summary>
	private Vector2 start;
	/// <summary> The end position of the enemy's movement </summary>
	private Vector2 end;
	/// <summary> The current destination of the enemy's movement </summary>
	private Vector2 goalPos;
	private int dir = 1; // 1 for start->end, -1 for start<-end

	public override void _Ready()
	{
		// Set up sfx
		streams[0] = GD.Load<AudioStream>("res://sfx/hurt.wav");
		streams[1] = GD.Load<AudioStream>("res://sfx/shoot.wav");
		// Set up stats
		health = new HealthComponent(new StatsComponent(healthStat, strengthStat, speedStat), this);
		audio = GetNode<AudioStreamPlayer2D>("SFX");
		// Get and add all turret children to the list
		foreach(Node n in this.GetChildren())
		{
			if(n.GetType() == typeof(Timer))
			{
				timer = (Timer) n;
			}
			else if(n.GetType() == typeof(Turret))
			{
				turrets.Add((Turret) n);
			}
			else if(n.GetType() == typeof(Line2D))
			{
				start = ((Line2D) n).Points[0];
				end = ((Line2D) n).Points[1];
				// Hide the path so it isn't visible
				// Adjust for this position
				start = new Vector2(Position.X + start.X, Position.Y + start.Y);
				end = new Vector2(Position.X + end.X, Position.Y + end.Y);
				((Line2D) n).Width = 0;
				goalPos = end;
			}
		}
		ChangePattern();
	}

	public override void _PhysicsProcess(double delta)
	{
		// Check if we need to swap directions
		if (Position.DistanceTo(goalPos) < 10)
		{
			// Change goal and facing direction
			goalPos = (goalPos == start) ? end : start;
			Scale = (goalPos == start) ? new Vector2(1, 1) : new Vector2(-1, 1);
		}
		// Move to goalPos
		Position = Position.Lerp(goalPos, (float) (speedStat * delta));
	}

	/// <summary>
	/// Switch patterns when timer runs out
	/// </summary>
	public void _on_timer_timeout()
	{
		ChangePattern();
	}

	/// <summary>Change the different properties to match the pattern</summary>
	public void ChangePattern()
	{
		int random = GD.RandRange(0, patterns.Length - 1);
		ProjectilePattern n_pattern = new ProjectilePattern(patterns[random]);
		foreach(Turret tt in turrets)
		{
			tt.PrepareTurret(n_pattern);
		}
		// Restart pattern timer
		timer.Stop();
		timer.WaitTime = n_pattern.Pattern_Time;
		timer.Start();
	}

	/// <summary>
	/// Remove health from the enemy upon being hit by the player
	/// </summary>
	/// <param name="dmg">The amount of damage to take</param>
	public void TakeDamage(int dmg)
	{
		audio.Stream = streams[0];
		audio.Play();
		health.TakeDamage(dmg);
	}

	/// <summary>
	/// Event to play the shooting sound when a turret child fires
	/// </summary>
	public void PlayShootSound()
	{
		audio.Stream = streams[1];
		audio.Play();
	}

	/// <summary>
	/// Destroy this enemy node if its health <= 0
	/// </summary>
	public void Die()
	{
		QueueFree();
	}
}

