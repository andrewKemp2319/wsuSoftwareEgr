using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
/// <summary>
/// Testing enemy spawning and stats
/// </summary>
public partial class test_Enemy_Base : Node
{
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
	}

	/// <summary>
	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	/// </summary>
	/// <param name="delta"></param>
	public override void _Process(double delta)
	{
	}
	private EnemyBase enemyBase;
	private Timer timer;
	public List<Turret> turrets;

/// <summary>
/// Building the test parameters
/// </summary>
	public void Setup()
	{
		enemyBase = new EnemyBase();
		timer = new Timer();
		turrets = new List<Turret>();

		foreach (Node n in enemyBase.GetChildren())
		{
			if (n.GetType() == typeof(Timer))
			{
				timer = (Timer)n;
			}
			else if (n.GetType() == typeof(Turret))
			{
				turrets.Add((Turret)n);
			}
		}
	}

	/// <summary>
	/// Testing the different projectile patterns
	/// </summary>
	public void ChangePattern_ChangesTurretProperties()
	{
		Turret firstTurret = turrets[0];
		String oldPattern = firstTurret.GetPattern();
		enemyBase.ChangePattern();

		foreach (Turret tt in turrets)
		{
			if(oldPattern != tt.GetPattern()){
				System.Console.WriteLine("Test Passed");
			} else {
				System.Console.WriteLine("Test Failed");
			}
		}
	}

	public void ChangePattern_ResetsTimer()
	{
		Turret firstTurret = turrets[0];
		String oldPattern = firstTurret.GetPattern();
		ProjectilePattern pattern = new ProjectilePattern(oldPattern);
		timer.Stop();
		timer.WaitTime = pattern.Pattern_Time;
		timer.Start();
		while(timer.TimeLeft > 0){
			System.Console.WriteLine("Waiting for timer to timeout");
		}
		foreach (Turret tt in turrets)
		{
			if(oldPattern != tt.GetPattern()){
				System.Console.WriteLine("Test Passed");
			} else {
				System.Console.WriteLine("Test Failed");
			}
		}
}
}