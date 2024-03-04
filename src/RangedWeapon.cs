using Godot;
using System;

/// <summary>
/// Constructing the ranged weapons
/// </summary>
public partial class RangedWeapon : Weapon
{
	/* Ranged Weapons have a few unique components:
        - A reference to the projectile scene they spawn
		- A "muzzle" object where projectiles spawn from
		- A projectile speed
		- A projectile "type" like enemies have
    */

	[Export]
	/// <summary> A reference to the projectile object to spawn </summary>
	private PackedScene projScene;

	[Export]
	/// <summary> The speed of spawned projectiles </summary>
	private float pSpeed = 20;

	[Export]
	/// <summary> The "Type" of this projectile </summary>
	private ProjType m_type;

	/// <summary> The point on this weapon to spawn projectiles at. </summary>
	private Node2D muzzle;
	
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
		base._Ready();
		muzzle = GetChild<Node2D>(0);
	}

	/// <summary>
	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	/// </summary>
	/// <param name="delta"></param>
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
	}

	/// <summary>
	/// An override of useWeapon that spawns a projectile object
	/// </summary>
    public override void useWeapon()
    {
        base.useWeapon();
		// Create and set up projectile
		Projectile _newProj = projScene.Instantiate<Projectile>();
		_newProj.PrepareProjectile(pSpeed, m_type, true);
		GetTree().Root.GetChild(0).AddChild(_newProj);
		_newProj.GlobalPosition = muzzle.GlobalPosition;
		_newProj.Rotation = GetParent<Node2D>().GlobalRotation + (float) (Math.PI / 2);
    }

	/// <summary>
	/// An override of the onTimer that allows this weapon to fire again.
	/// </summary>
    public override void onTimer()
    {
        base.onTimer();
    }
}
