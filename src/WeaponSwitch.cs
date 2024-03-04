using Godot;
using System;

/// <summary>
/// Switching weapons in the characters hands
/// </summary>
public partial class WeaponSwitch : Node2D
{
	/// <summary>
	/// The weapon this Switch has
	/// </summary>
	private Weapon mWeapon;
	/// <summary>
	/// Reference to an AudioPlayer to play sound effects
	/// </summary>
	private AudioStreamPlayer2D audio;
	/// <summary>
	/// Reference to a popup telling the player what button to press.
	/// </summary>
	private Label interactLabel;
	/// <summary>
	/// Reference to the animation player that makes interactLabel bounce.
	/// </summary>
	private AnimationPlayer anim;
	/// <summary>
	/// Reference to the player made when they enter this Switch's range
	/// </summary>
	private player p;
	/// <summary>
	/// Can the player use this Switch if input is received?
	/// </summary>
	private bool canInteract = false;

	/// <summary>
	/// How much to add to x coord when switching
	/// </summary>
	const float WEAPON_OFFSET_X = 25; 

	/// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer2D>("SFX");
		/// Find the weapon component
		foreach(Node c in GetChildren())
		{
			if(c.GetType() == typeof(RangedWeapon) || c.GetType() == typeof(MeleeWeapon))
			{
				mWeapon = (Weapon)c;
				mWeapon.setUse(false);
			}
			if(c.GetType() == typeof(Label))
			{
				interactLabel = (Label) c;
			}
			if(c.GetType() == typeof(AnimationPlayer))
			{
				anim = (AnimationPlayer) c;
			}
		}
		interactLabel.Visible = false;
	}

	/// <summary>
	/// Called every frame. 'delta' is the elapsed time since the previous frame.
	/// </summary>
	/// <param name="delta"></param>
	public override void _Process(double delta)
	{
		if(canInteract && Input.IsActionJustPressed("interact"))
		{
			audio.Play();
			// Get the player's weapon, and switch it with the current weapon
			Weapon pWeapon = p.GetNode("weapon pivot").GetChild<Weapon>(0);
			/// Remove player's old weapon
			pWeapon.setUse(false);
			p.GetNode("weapon pivot").RemoveChild(pWeapon);
			AddChild(pWeapon);
			pWeapon.Position = Vector2.Zero;
			/// Give player new weapon
			RemoveChild(mWeapon);
			p.GetNode("weapon pivot").AddChild(mWeapon);
			mWeapon.Position = new Vector2(WEAPON_OFFSET_X, 0);
			mWeapon.setUse(true);

			/// Change mWeapon
			mWeapon = pWeapon;
		}
	}

	/// <summary>
	/// Runs when a physics body enters this Area2D's monitoring range.
	/// </summary>
	/// <param name="body">The physics body that enteres this Area2D. </param>
	public void _on_area_2d_body_entered(Node2D body)
	{
		if(body.GetType() == typeof(player))
		{
			p = (player) body;
			canInteract = true;
			interactLabel.Visible = true;
			anim.CurrentAnimation = "Interact_Bob";
			anim.Play();
		}
	}

	/// <summary>
	/// Runs when a physics body exits this Area2D's monitoring range.
	/// </summary>
	/// <param name="body">The physics body that exited this Area2D. </param>
	public void _on_area_2d_body_exited(Node2D body)
	{
		if(body.GetType() == typeof(player))
		{
			p = null;
			canInteract = false;
			interactLabel.Visible = false;
			anim.Stop();
		}
	}
}
