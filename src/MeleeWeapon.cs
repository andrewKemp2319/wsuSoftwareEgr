using Godot;
using System;

/// <summary>
/// Constructing the melee weapons 
/// </summary>
public partial class MeleeWeapon : Weapon
{
/** Melee Weapons have a few unique components:
        - A hit effect Sprite that acts like the "slash"
        - An Area2D hitbox attached to the hit effect that hurts enemies when enabled
        - A CollisionShape2D that defines the hitbox of the weapon's damaging area
    */

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    /// <summary>
    /// An override of useWeapon that enables this weapon's hitbox
    /// </summary>
    public override void useWeapon()
    {
        base.useWeapon();
        /// Turn on hit effect
        ((Node2D)pivot.GetChild(0).GetChild(0)).Visible = true;
        /// Turn on hitbox
        ((Area2D)pivot.GetChild(0).GetChild(0).GetChild(0)).Monitoring = true;
    }

    /// <summary>
    /// An override of the onTimer that disables this weapon's hitbox after being activated.
    /// </summary>
    public override void onTimer()
    {
        base.onTimer();
        /// Turn off hit effect
        ((Node2D)pivot.GetChild(0).GetChild(0)).Visible = false;
        /// Turn off hitbox
		((Area2D)pivot.GetChild(0).GetChild(0).GetChild(0)).Monitoring = false;
    }

    /// <summary>
    /// This method is called when a PhysicsBody2D interacts with the weapon's hitbox
    /// body == The other object
    /// </summary>
    /// <param name="body"></param>
    public void _on_area_2d_body_entered(Node2D body)
    {
        /// The opposing body is an Enemy, deal damage
        if(body.GetType() == typeof(EnemyBase))
        {
            ((EnemyBase) body).TakeDamage(damage);
        }
    }
}