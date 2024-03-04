using Godot;
using System;

/// <summary>
/// Adding the name and the sprite texture to the array so the items will show up right.
/// </summary>
public partial class inventoryItem : Node{
<<<<<<< HEAD
	//Andrew Johnston's Addition 
	//Adding the name and the sprite texture to the array so the items will show up right.
=======
	
>>>>>>> e12dd717b9d76e3bd8738886be97fd83065ffb74
	[Export]
	public string name { get; set; }
	[Export]
    public Texture Texture { get; set; }
}
