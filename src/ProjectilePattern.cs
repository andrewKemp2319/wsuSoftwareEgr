using Godot;
using System;


/*
	ProjectilePatterns manage how enemies launch 1 wave, or round, of projectiles.

	Enemies cycle between ProjectilePatterns for different attacks, loading the properties of one and
	executing that attack before moving on to the next.
*/

/// <summary>A struct managing info over one "wave" of projectiles</summary>
public struct ProjectilePattern {

	public ProjectilePattern()
	{
		Proj_Speed = 20;
		Proj_Type = ProjType.Normal;
		Turret_Speed = 5;
		Track_Player = false;
		Pattern_Time = 5;
	}

	// Patterns can be represented as: "pSpeed-type-tSpeed-track-time"
	//	See Projectile.cs to see int->ProjType conversion
	public ProjectilePattern(string pattern)
	{
		string[] fmt = pattern.Split("-");
		try {
			Proj_Speed = float.Parse(fmt[0]);
			Proj_Type = (ProjType) int.Parse(fmt[1]);
			Turret_Speed = float.Parse(fmt[2]);
			Track_Player = bool.Parse(fmt[3]);
			Pattern_Time = float.Parse(fmt[4]);
		}
		catch (Exception e)
		{
			GD.PrintErr("Pattern " + fmt + " could not be loaded, using default pattern");
			Proj_Speed = 20;
			Proj_Type = ProjType.Normal;
			Turret_Speed = 5;
			Track_Player = false;
			Pattern_Time = 5;
		}
	}

	/// <summary>
	/// How fast projectiles move
	/// </summary>
	public float Proj_Speed { get; }
	/// <summary>
	/// The type of projectile used in this pattern
	/// </summary>
	public ProjType Proj_Type { get; }
	/// <summary>
	/// How fast the turrets fire
	/// </summary>
	public float Turret_Speed { get; }
	/// <summary>
	///  Should projectiles follow the player?
	/// </summary>
	public bool Track_Player { get; }
	/// <summary>
	/// How long this pattern lasts for
	/// </summary>
	public float Pattern_Time { get; }
	public String GetPattern(){
		return $"{Proj_Speed}-{(int)Proj_Type}-{Turret_Speed}-{Track_Player}";
	}
}