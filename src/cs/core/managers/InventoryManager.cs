/**
	Detective-style problem-solving magical rpg
	Copyright (C) 2023 Rainy Day Studio

	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Godot;
using System;
using System.Diagnostics;
using System.Linq;

// Models the player's inventory
public partial class InventoryManager : Node2D {

	// ==================== Inventory Definitions=================

	// ==================== Inventory Signals ====================

	// ==================== Inventory Exports ====================
	// Number of inventory slots
	[Export]
	int InventorySize = 3*7;

	// Inventory name
	[Export]
	string InventoryName = "newInventory";

	// ==================== Children Nodes =======================
	// The Inventory's sprite (i.e. visual element)
	private CanvasLayer GUIBackground;

	// ==================== Internal fields ====================
	// Stores the actual inventory
	private Inventory Inv;

	// Context
	private Context C;

	// Item DB
	private ItemManager IM;

	// ==================== GODOT Method Overrides ====================
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch Child node
		GUIBackground = GetNode<CanvasLayer>("CanvasLayer");

		// Fetch Context
		C = GetNode<Context>("/root/Context");

		// Fetch appropriate Inventory from context
		Inv = C._GetInventory(InventoryName);
		
		// Fetch Item DB
		IM = GetNode<ItemManager>("/root/ItemManager");

		Close();
	}


 	// ==================== Local Methods ====================

	// Adds Item to specified Inventory.
    // Returns true if successful, false if not.
	// TODO: handle getting more items than stack size
    private bool AddItem(Item newItem, int count) {

        // Sort by slot position
        var orderedByPosition = Inv.Contents
            .Select((slot, idx) => (slot, idx))
            .OrderBy(sloti => sloti.slot.position).ToList();

        // Find list of the all valid slots containing newItem
        var filteredList = orderedByPosition.Where(sloti =>
                sloti.slot.item.name == newItem.name &&
                sloti.slot.count + count <= newItem.stackSize
            ).ToList();

        if(filteredList.Any()) {
            // Add items to slot
            Inv.UpdateCount(filteredList[0].idx, count);

        } else {
            // New inventory slot:
            // Fail if all slots are used
            if (Inv.Contents.Count >= Inv.MaxSize) {
                return false;
            }

            // To find first empty slot, iterate through sorted list by slot position.
            // For the first position that doesn't correspond to the loop counter, the loop
            // counter gives the position.
            int newPosition = -1;
            for(int i = 0; i < Inv.Contents.Count; i++) {
                if (orderedByPosition[i].slot.position != i) {
                    newPosition = i; 
                    break;
                }
            }

            Inv.Contents.Add(new(newItem,newPosition,count));
        }
        return true;
    }

	// ==================== Public API ====================

	// Adds Item to inventory by name
	public bool AddItemName(string itemName, int count) {
		Item newItem = IM.GetItem(itemName, count);

		return AddItem(newItem, count);
	}
	
	// Called when inventory is opened
	public void Open() {
		Show();
		GUIBackground.Show();
	}

	// Called when inventory is closed
	public void Close() {
		Hide();
		GUIBackground.Hide();
	}
}

