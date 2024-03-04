using Godot;
using System;

/// <summary>
/// Creating a turret enemy
/// </summary>
public partial class Turret : Node2D
{
	/// <summary>Projectile scene to instantiate</summary>
	private PackedScene ProjectileObj;
	/// <summary>The point to spawn projectiles</summary>
	private Node2D Muzzle;
	/// <summary>Counter for current cooldown time</summary>
	private float cooldown;
	private float pSpeed = 20;

	[Export]
	/// <summary> Max time to cool down before firing. </summary>
	private float MAX_COOLDOWN_TIME = 5;

	[Export]
	/// <summary> The type of ALL projectiles spwaned from this turret. </summary>
	private ProjType m_type = ProjType.Normal;

	[Signal]
	/// <summary> Event that activates when the turret fires. </summary>
	public delegate void OnFireEventHandler();

    public override void _Ready()
    {
        ProjectileObj = GD.Load<PackedScene>("res://objects/Projectile.tscn");
		Muzzle = GetChild<Node2D>(0);
		cooldown = MAX_COOLDOWN_TIME;
    }

    public override void _PhysicsProcess(double delta)
    {
		if(cooldown <= 0)
		{
			Projectile _newProj = ProjectileObj.Instantiate<Projectile>();
			_newProj.PrepareProjectile(pSpeed, m_type);
			GetTree().Root.GetChild(0).AddChild(_newProj);
			_newProj.GlobalPosition = Muzzle.GlobalPosition;
			_newProj.Rotation = this.GlobalRotation - (float) (Math.PI / 2);
			cooldown = MAX_COOLDOWN_TIME;
			EmitSignal(SignalName.OnFire);
		}
		else
		{
			cooldown -= 0.1f;
		}
    }

	/// <summary>Loads turret parameters from a projectile pattern</summary>
	/// <param name="pat">The pattern to change this turret to</param>
	public void PrepareTurret(ProjectilePattern pat)
	{
		MAX_COOLDOWN_TIME = pat.Turret_Speed;
		cooldown = MAX_COOLDOWN_TIME;
		pSpeed = pat.Proj_Speed;
		m_type = pat.Proj_Type;
	}
	public String GetPattern(){
		return GetPattern();
	}
	
	public float GetCooldown(){
		return cooldown;
	}
}
