# Assignment Due Date
[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/Y-8z8yPz)

# Godot Installation Guide (C# ver.)
By: Ethan Heinlein (feel free to ping or DM)

### Required Software:
| Name | Link | Reason |
|-----|-----|----|
| .NET SDK v6 | [SDK](https://dotnet.microsoft.com/download) | Required to compile C# code |
| Doxygen | [Doxy](https://www.doxygen.nl/) | Class requirement (fully supports C#)
| Godot v4.1.1 | [Godot](https://github.com/godotengine/godot/releases/download/4.1.1-stable/Godot_v4.1.1-stable_mono_win64.zip) | Engine download. This version has C# support

### Recomended Software:
| Name | Link | Reason |
|----|----|----|
| VS Code | [Microsoft](https://code.visualstudio.com/download) | If you don't have an IDE, VS code is very good, and has good extensions for Godot

### VSCode Extensions:
| Name | Link | Reason |
|----|----|----|
| C# Extension | [Ext](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) | Language support |
| Godot C# Tools | [Ext](https://marketplace.visualstudio.com/items?itemName=neikeq.godot-csharp-vscode) | Utilities and Intellisense

## Installation Steps
1. Download and install the .NET SDK (follow wizard to completion)
> You can verify the install by entering **dotnet --version** in a terminal.
2. Download and extract the Godot engine. Make sure it's the version with C# support (the "louder" link on their website is the one with **just** GDScript support)
> The C# version should contain a folder named **GodotSharp**, make sure your installation has this folder.
3. The exe bundled with Godot, **godot-stable-mono...** is the executable for the engine itself, not an installer. Double click it to run Godot.
> I'd recommend moving the zip's contents to a folder and creating a shortcut of the **godot-stable-mono...** exe on your desktop.

If you run into any problems, Godot has a [Troubleshooting page here](https://docs.godotengine.org/en/stable/about/troubleshooting.html).

Godot docs can be found [here](https://docs.godotengine.org/en/stable/index.html).