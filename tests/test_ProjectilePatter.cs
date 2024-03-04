using Godot;
using System;

/// <summary>
/// Testing projectile patterns
/// </summary>
public partial class test_ProjectilePattern : Node
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
	/// <summary>
	/// Test for how the pattern is constructor for the enemy
	/// </summary>
	public void TestProjectilePatternConstructor() {
		
		string patternString = "50-1-2-false-10";

		
		ProjectilePattern pattern = new ProjectilePattern(patternString);

		if(pattern.Proj_Speed == 50 && pattern.Proj_Type == ProjType.Normal && pattern.Turret_Speed == 2 && pattern.Track_Player == false && pattern.Pattern_Time == 10){
			System.Console.Write("Test passed");
			} else {
				System.Console.Write("Test failed");
			}
}
}
