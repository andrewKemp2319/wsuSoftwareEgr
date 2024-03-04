using Godot;
using System;

/// <summary>
/// Testing the construction of turrets and functionality
/// </summary>
public partial class test_turret : Node
{
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
	}

	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	Turret turret;
	ProjectilePattern pattern;

	/// <summary>
	/// Creating new turret
	/// </summary>
	public void Setup()
	{
		turret = new Turret();
		pattern = new ProjectilePattern();
	}

	/// <summary>
	/// Testing for the turret shooting projectiles
	/// </summary>
	public void TurretShouldInstantiateProjectile()
	{
		turret.PrepareTurret(pattern);
		if(turret.GetTree().Root.GetChild(0).GetChildCount() == 0){
			turret._PhysicsProcess(0.1);
			if(turret.GetTree().Root.GetChild(0).GetChildCount() == 1){
				System.Console.Write("Test passed");
			} else {
				System.Console.Write("Test failed");
			}
		}
	}
	
	/// <summary>
	/// Testing the cooldown between turret shots
	/// </summary>
	public void TurretShouldRespectCooldown()
	{
		turret.PrepareTurret(pattern);
				if(pattern.Turret_Speed == turret.GetCooldown()){
			turret._PhysicsProcess(0.1);
			if(pattern.Turret_Speed - 0.1f == turret.GetCooldown()){
				System.Console.Write("Test passed");
			} else {
				System.Console.Write("Test failed");
			}
		}
	}
}
