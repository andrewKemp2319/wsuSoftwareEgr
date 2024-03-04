using Godot;
using System;

/// <summary>
/// Testing projectiles speed and patterns
/// </summary>
public partial class test_projectile : Node
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
	/// Testing the speed of how the projectiles move
	/// </summary>
	public void test_SpeedSetting()
	{
		
		Projectile projectile = new Projectile();
		float newSpeed = 30;

		projectile.PrepareProjectile(newSpeed, ProjType.Normal);
		
			if(newSpeed == projectile.GetSpeed()){
				System.Console.Write("Speed test passed");
			} else {
				System.Console.Write("Speed test failed");
			}
	}

	/// <summary>
	/// Testing the type of patterns the projectiles can follow
	/// </summary>
	public void test_TypeSetting()
	{
		
		Projectile projectile = new Projectile();
		ProjType newType = ProjType.Wave;

		
		projectile.PrepareProjectile(20, newType);

		if(newType == projectile.GetMyType()){
				System.Console.Write("Mytype test passed");
			} else {
				System.Console.Write("MyType test failed");
			}
	}
}