// StatsComponent.cs

using Godot;

/// <summary>
/// This is a component that stores the attributes of an entity
/// </summary>
public class StatsComponent : Component
{
    /// <summary>
    /// The attributes of the entity, such as health, strength, or speed
    /// </summary>
    public int health = 100;
    public int maxHealth = 100;
    public int strength = 10;
    public float speed = 5;

    public StatsComponent(int mh, int st, float sp)
    {
        maxHealth = mh;
        health = maxHealth;
        strength = st;
        speed = sp;
    }

    /// <summary>
    /// A method that modifies an attribute by a given amount
    /// </summary>
    /// <param name="stat"></param>
    /// <param name="amount"></param>
    public void ModifyStat(string stat, int amount)
    {
        /// You can add some logic here to check the validity of the stat and the amount
        /// For example, you can clamp the health and mana values between 0 and their maximums
        switch(stat.ToLower())
        {
            case "health":
                health += amount;
                break;

            case "maxhealth":
                maxHealth += amount;
                break;

            case "strength":
                strength += amount;
                break;

            case "speed":
                speed += amount;
                break;
        }
    }
}
