using Godot;
using System;

/// <summary>
/// Testing the player movement
/// </summary>
public partial class testplayer : Node
{
	/// Called when the node enters the scene tree for the first time.
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
/// <summary>
/// Testing the gravity mechanics while in air
/// </summary>
public void PlayerPhysics_ApplyGravity_WhenNotOnFloor()
{
	/// Arrange
	player player = new player();
	player.Velocity = new Vector2(0, 100);
	player.gravity = 50;
	var onFloor = player.IsOnFloor();
	if(onFloor==false){
	/// Act
	player._PhysicsProcess(0.1f);
	/// Test
	if (player.Velocity.Y == 150)
	{
		System.Console.Write("Gravity When Not On Floor Test Passed");
	}
	else
	{
		System.Console.Write("Gravity When Not On Floor Test Failed");
	}
	}
}
/// <summary>
/// Testing the gravity mechanics while on ground
/// </summary>
public void PlayerPhysics_NoGravity_WhenOnFloor()
{
	/// Arrange
	player player = new player();
	player.Velocity = new Vector2(0, 100);
	player.gravity = 50;
	var onFloor = player.IsOnFloor();
	if(onFloor==true){

	/// Act
	player._PhysicsProcess(0.1f);

	/// Test
	if (player.Velocity.Y == 100)
	{
		System.Console.Write("Gravity When On Floor Test Passed");
	}
	else
	{
		System.Console.Write("Gravity When On Floor Test Failed");
	}
	}
}

/// <summary>
/// Testing player jumping mechanic
/// </summary>
public void PlayerPhysics_Jump_IncreasesYVelocity()
{
	/// Arrange
	player player = new player();
	player.Velocity = new Vector2(0, 0);
	var onFloor = player.IsOnFloor();
	if(onFloor==true){

	/// Act
	player._PhysicsProcess(0.1f);

	/// Test
	if (player.Velocity.Y == -200.0f)
	{
		System.Console.Write("Jump Test Passed");
	}
	else
	{
		System.Console.Write("Jump Test Failed");
	}
	}
}
/// <summary>
/// Testing the double jump
/// </summary>
public void PlayerPhysics_DoubleJump_IncreasesYVelocity()
{
	/// Arrange
	player player = new player();
	player.Velocity = new Vector2(0, 0);
	var onFloor = player.IsOnFloor();
	if(onFloor==false){
	player.canDoubleJump = true;

	/// Act
	player._PhysicsProcess(0.1f);

	/// Test
	if (player.Velocity.Y == -200.0f){
		System.Console.Write("Double Jump Test Passed");
	}
	else
	{
		System.Console.Write("Double Jump Test Failed");
	}
	}
}
/// <summary>
/// Testing the crouch of the player
/// </summary>
public void PlayerPhysics_Crouching_StateUpdated()
{
	// Arrange
	player player = new player();
	var onFloor = player.IsOnFloor();
	if(onFloor==true){

	// Act
	player._PhysicsProcess(0.1f);

	// Test
	if (player.GetSpeed() == 100)
	{
		System.Console.Write("Crouching Test Passed");
	}
	else
	{
		System.Console.Write("Crouching Test Failed");
	}
	}
}
}
