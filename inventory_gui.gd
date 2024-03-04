extends Control

var inventoryState: bool = false

func open():
	visible = true
	inventoryState = true
	
func close():
	visible = false
	inventoryState = false
	
	## To toggle the inventory I added a 
	## the main toggle to the world scene 
	## then added a script to the canvas and this is a copy of the code from that script.
## 
## extends CanvasLayer
##
##  ## I added a reference to the InventoryGui 
## @onready var inventory = $InventoryGui
##
## func _ready():
## inventory.close()
##
## func _input(event):
##      ## On this step I went into project settings, then the input mapping section and added a new action named "toggle_inventory" and mapped it to a key
##      if event.is_action_pressed("toggle_inventory"):
##           if inventory.inventoryState:
##                inventory.close()
##           else:
##                inventory.open()
##
##
