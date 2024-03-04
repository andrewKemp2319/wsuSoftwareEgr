using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// The Array for inventory slots and items
/// </summary>
public partial class inventoryarray : Resource{
<<<<<<< HEAD
    //Andrew Johnston's Addition 
    //Just Exports the Resources that are made into an array for the items to be stored in.
=======
    /// <summary>
    /// Just Exports the Resources that are made into an array for the items to be stored in.
    /// </summary>
>>>>>>> e12dd717b9d76e3bd8738886be97fd83065ffb74
    [Export]
    public Godot.Collections.Array<Resource> Items = new Godot.Collections.Array<Resource>();
}
