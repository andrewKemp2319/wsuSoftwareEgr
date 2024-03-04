using Godot;
using System;

// Component.cs
/// <summary>
/// This is the base class for all components
/// </summary>
public class Component
{
	/// <summary>
	/// A virtual method that can be overridden by subclasses to update the component logic
	/// </summary>
	/// <param name="deltaTime"></param>
	public virtual void Update(float deltaTime)
	{

	}
}


