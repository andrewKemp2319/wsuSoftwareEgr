using Godot;
using System;

/// <summary>
/// Creating the character's physics and pulling the character's stats
/// </summary>
public partial class player : CharacterBody2D{
	///Speed variables for various actions, edit to alter physics of related actions
	public const float jumpVelocity = -200.0f;
	public const float dashVelocity = 5000.0f;
	public const float doubleJumpVelocity = -200.0f;
	public const float wallJumpVelocity = -200.0f;
	public const float wallPushback = -2000.0f;

	/// <summary>
	/// Stats system
	/// </summary>
	private StatsComponent stats = new StatsComponent(100, 5, 200);
	private HealthComponent health;

	private AudioStreamPlayer2D audio;

	// Variables for animation handling
	private AnimationPlayer _animationPlayer;
	private Sprite2D sprite;
	public string animation = "Idle";
	bool notCrawling = true;

	private AudioStream[] streams = new AudioStream[2]; // 0 == Hurt, 1 == Jump

	[Export]
	public Resource Inventory { get; set; }

	/// <summary>
	/// Get the gravity from the project settings to be synced with RigidBody nodes.
	/// </summary>
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	/// booleans for whether actions are available or not
	public bool canDoubleJump = true;
	public bool canDash = true;
	public bool wallJumpPushback = false;
	public bool canLeftWallJump = true;
	public bool canRightWallJump = true;
	public Vector2 direction;

	public override void _Ready()
    {
		/// Create new health component
        health = new HealthComponent(stats, this);
		audio = GetNode<AudioStreamPlayer2D>("SFX");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		sprite = GetNode<Sprite2D>("Sprite");
		// Load audio resources
		streams[0] = GD.Load<AudioStream>("res://sfx/hurt.wav");
		streams[1] = GD.Load<AudioStream>("res://sfx/jump.wav");
    }

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		var collision = GetNode<CollisionShape2D>("CollisionShape2D");
		var crouchCollision = GetNode<CollisionShape2D>("CrouchShape");

		/// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			if (velocity.Y >= 0) {
				animation = "Jump_Fall";
				Animate();
			}
			else if (Velocity.Y < 0) {
				animation = "Jump_Rise";
				Animate();
			}
		}
		else { //If player is on floor, reset double jump and wall jump capabilities
			canDoubleJump = true;
			canLeftWallJump = true;
			canRightWallJump = true;
		}

		//Animate running on ground
		if(IsOnFloor()) {
			if(velocity.X != 0 && notCrawling) {
				animation = "Run";
				Animate();
			}
			else if (velocity.X == 0 && notCrawling) {
				animation = "Idle";
				Animate();
			}
		}

		/// If player is in the middle of a wall jump, don't check for movement
		/// to simulate end lag
		if (wallJumpPushback)
			return;

		/// Handle Jump, double jump, wall jump
		if (Input.IsActionJustPressed("jump")) {
			if (IsOnFloor()) {
				audio.Stream = streams[1];
				audio.Play();
				velocity.Y = jumpVelocity;
			} else if (IsOnWall()
					   && (Input.IsActionPressed("left") && canLeftWallJump)
					   || (Input.IsActionPressed("right") && canRightWallJump)) { //if the player is touching a wall, wall jump
				velocity.Y = wallJumpVelocity;
				velocity.X = direction.X * wallPushback;

				Velocity = velocity;
				MoveAndSlide();

				if (Input.IsActionPressed("left")) {
					canLeftWallJump = false;
					canRightWallJump = true;
				} else if (Input.IsActionPressed("right")) {
					canLeftWallJump = true;
					canRightWallJump = false;
				}
				/// Add a small timer to disable movement to simulate end lag after wall jump
				wallJumpPushback = true;
				var timer = GetNode<Timer>("wallJumpPushbackTimer");
				timer.Start();
			} else if (canDoubleJump) { //if player is in air and can double jump, jump and dont let them jump again
				audio.Stream = streams[1];
				audio.Play();
				velocity.Y = doubleJumpVelocity;
				canDoubleJump = false;
				canLeftWallJump = true;
				canRightWallJump = true;
			} 
		}

		/// Handle dash
		if (Input.IsActionJustPressed("dash")) {
			if (canDash) {
				canDash = false;
				animation = "Dash";
				Animate();
				velocity.X = direction.X * dashVelocity;
				
				var timer = GetNode<Timer>("dashTimer");
				timer.Start();
			}

			Velocity = velocity;
			MoveAndSlide();
		}
			
		/// Handle crouch
		if (Input.IsActionPressed("crouch") && IsOnFloor()) { //Set hitbox and reduce speed
			collision.SetDeferred("disabled", true);
			crouchCollision.SetDeferred("disabled", false);
			stats.speed = 100;
			if (velocity.X == 0) {
				animation = "Crouch";
				Animate();
				notCrawling = true;
			}
			else if (velocity.X != 0 && notCrawling) {
				animation = "Crawl";
				Animate();
				notCrawling = false;
			}
			
		} else { /// Set hitbox and increase speed
			collision.SetDeferred("disabled", false);
			crouchCollision.SetDeferred("disabled", true);
			stats.speed = 200;
		}

		if (Input.IsActionJustReleased("crouch")) {
			notCrawling = true;
		}


		/// Get the input direction and handle the movement/deceleration.
		/// As good practice, you should replace UI actions with custom gameplay actions.
		direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * stats.speed;
			// Moving right
			if (velocity.X > 0) {
				sprite.FlipH = false;
				}
			// Moving left
			else if (velocity.X < 0) {
				sprite.FlipH = true;
				}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, stats.speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int amt)
	{
		audio.Stream = streams[0];
		audio.Play();
		health.TakeDamage(amt);
	}

	public void Animate() {
		_animationPlayer.Play(animation);
	}

	public float GetSpeed()
	{
		return stats.speed;
	}

	public void Die()
	{
		/// TODO: Add gameover event
	}

	private void OnDashTimerTimeout()
	{
    	canDash = true;
	}

	private void OnWallJumpPushbackTimerTimeout() {
		wallJumpPushback = false;
	}
	//Andrew Johnston's Addition 
	///This Method calls the method name that is tied to the player's Area2D Box.
	public void _on_item_hitbox_area_entered(Area2D area){
		//This is checking to make sure that the Collectable Methods exist's
		if(area.HasMethod("Collectable")){
			//And if it does, then it class the Collectable Method.
			area.Call("Collectable");
		}
    }

}
