using Godot;
using System;

/*! \mainpage Team I got Nothing
    \section intro_sec Introduction

    Team I got Nothing created a rogue like game


*/





/// <summary>
<<<<<<< HEAD
/// //Andrew Johnston's Addition 
/// This class helps set up the visibility of the players inventory and allows the opening and closing of it in a single button. 
=======
/// Inventory setup for seeting up the menu to remain in the same position 
>>>>>>> e12dd717b9d76e3bd8738886be97fd83065ffb74
/// </summary>
public partial class CanvasLayer : Godot.CanvasLayer{
    Inventory inventory;
    public override void _Ready(){
    ///Making sure that the inventory is closed at the time the game is being launched  
    var inventory = GetNode<Inventory>("Inventory");
    inventory.close();
    }
    
    public override void _Input(InputEvent @event) {
    ///Basic command calling the inventory
        var inventory = GetNode<Inventory>("Inventory");
    ///If-else looking for the toogle inventory command that is the button thats assigend to it. 
    if (@event.IsActionPressed("toggle_inventory")) {
        ///If the inventory is open and you hit the button then it closes it.
        if (inventory.isOpen){
            inventory.close();
        }
        else{
            ///If the inventory is open and you hit the button then it closes it.
            inventory.open();
        }
}
    }
}
