using Godot;
using System;

///	<summary>
///	Enum for controlling the general projectile path (according to rotation)
///	</summary>
public enum ProjType {
	/// <summary>Projectile moves forward</summary>
	Normal,
	/// <summary>Projectile moves in a sine wave pattern</summary>
	Wave, 
	/// <summary>Projectile moves in a clockwise curve</summary>
	Curve_CW,
	/// <summary>Projectile moves in an anti-clockwise curve</summary>
	Curve_ACW
	};

/// <summary>
/// Setting up the projectiles the character and enemies shoot
/// </summary>
public partial class Projectile : CharacterBody2D
{
	[Export]
	/// <summary>The speed of the projectile (in Godot units)</summary>
	private float speed = 20;

	/// <summary>
	/// The amount of damage this projectile does
	/// </summary>
	private int damage = 2;

	/// <summary>
	/// Is this projectile from the player? If so damage enemies, not the player
	/// </summary>
	private bool fromPlayer = false;

	[Export]
	/// <summary>The travel path type of this projectile</summary>
	private ProjType MyType = ProjType.Normal;

	/// <summary>Arbitrary constant to avoid obnoxiously large <see cref="Speed" /> values</summary>
	private const int PROJ_SPEED_CONSTANT = 1500;
	private float WaveCounter = 0;

	public float GetSpeed()
	{
		return speed;
	}

	public void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	public ProjType GetMyType()
	{
		return MyType;
	}

	public void SetMyType(ProjType newMyType)
	{
		MyType = newMyType;
	}

	/// <summary>
	/// Apply velocity according to <see cref="MyType" />, and move the projectile
	/// </summary>
	/// <param name="delta">The time elapsed during 1 frame, used to normalize movement for varying framerates</param>
    public override void _PhysicsProcess(double delta)
    {
		this.Velocity = Vector2.Up.Rotated(this.Rotation) * (speed * PROJ_SPEED_CONSTANT * (float) delta);
		if(MyType == ProjType.Wave)
			this.Position = new Vector2(this.Position.X, this.Position.Y + 5 * (float) Math.Cos(WaveCounter+=(float) delta * 10));
		else if (MyType == ProjType.Curve_CW)
			this.Rotate((float) delta);
		else if (MyType == ProjType.Curve_ACW)
			this.Rotate(-(float) delta);
        this.MoveAndSlide();
    }

	/// <summary>
	/// Runs when a physics body touches the projectile (wall, floor, or entity)
	/// </summary>
	/// <param name="body">The physicsbody this projectile touched</param>
	public void _on_area_2d_body_entered(Node2D body)
	{
		// Figure out what was hit
		if (body.GetType() == typeof(player) && !fromPlayer)
		{
			((player) body).TakeDamage(damage);
			QueueFree();
		}
		else if (body.GetType() == typeof(EnemyBase) && fromPlayer)
		{
			((EnemyBase) body).TakeDamage(damage);
			QueueFree();
		}
		else if (body.GetType() != typeof(player) && body.GetType() != typeof(EnemyBase))
		{
			QueueFree();
		}

	}

	/// <summary>
	/// Adjusts a projectile's properties
	/// </summary>
	/// <param name="n_speed">New Speed</param>
	/// <param name="n_type">New Type</param>
	public void PrepareProjectile(float n_speed, ProjType n_type, bool playerP = false)
	{
		speed = n_speed;
		MyType = n_type;
		fromPlayer = playerP;
	}

}
