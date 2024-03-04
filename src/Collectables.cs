using Godot;
using System;

<<<<<<< HEAD
////Andrew Johnston's Addition 
///
public partial class Collectables : Area2D{
    //This method is a very basic one but it prints out the fact that an item was picked up
=======
/// <summary>
/// Setting up how the collectible items function
/// </summary>
public partial class Collectables : Area2D{

    /// <summary>
    /// Runs when the Collectable is touched by the player. Runs once before node is deleted.
    /// </summary>
>>>>>>> e12dd717b9d76e3bd8738886be97fd83065ffb74
    public void Collectable(){
        GD.Print("Item collected!");
        //This allows the item to disappear once the players hitbox interacts with the item's hitbox
        QueueFree();
    }
}

