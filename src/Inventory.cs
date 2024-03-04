using Godot;
using System;

/// <summary>
/// //Andrew Johnston's Addition 
///This class is the basis of just opening up and closing the inventory
/// </summary>
public partial class Inventory : Control{

	/// <summary>
	/// Setting the boolean variable to false 
	/// </summary>
	public bool isOpen = false;

	/// <summary>
	/// Simple methods that sets open to true 
	/// </summary>
	public void open(){
		Visible = true;
		isOpen = true;
	}
	/// <summary>
	//Simple methods that sets close to false 
	/// </summary>
	public void close(){
		Visible = false;
		isOpen = false;
	}
}




