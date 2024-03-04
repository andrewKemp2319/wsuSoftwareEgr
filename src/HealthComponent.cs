using Godot;
using System;

// HealthComponent.cs
/// <summary>
/// This is a component that handles the health and damage logic of an entity
/// </summary>
public class HealthComponent : Component
{
    /// <summary>
    /// A reference to the stats component of the entity
    /// </summary>
    private StatsComponent stats;
    /// <summary>
    /// A reference to the entity these stats are attached to (Player or Enemy)
    /// </summary>
    private Variant entity;

    public HealthComponent(StatsComponent s, Variant self)
    {
        entity = self;
        stats = s;
    }

    /// <summary>
    /// A method that is called when the entity takes damage
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        /// Reduce the health by the damage amount
        stats.ModifyStat("health", -amount);
        /// Check if the health reaches zero
        if (stats.health <= 0)
        {
            /// Call a method to handle the death of the entity
            Die();
        }
    }

    public int GetHealth()
    {
        return stats.health;
    }

    /// <summary>
    /// A method that is called when the entity dies
    /// </summary>
    public void Die()
    {
        /// Check what the entity this Health attached to is
        if(entity.AsGodotObject().GetType() == typeof(EnemyBase))
        {
            /// If enemy, do EnemyBase death (Queuefree)
            ((EnemyBase) entity.AsGodotObject()).Die();
        }
        else if(entity.AsGodotObject().GetType() == typeof(player))
        {
            /// If player, do player death (Gameover event)
            ((player) entity.AsGodotObject()).Die();
        }
    }
}