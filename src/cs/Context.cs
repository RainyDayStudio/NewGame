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
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

// Global state of the game
// Records all persistent data for the game
// This is what we would want to serialize in order to save it.
public partial class Context : Node {

    // ==================== Context Signals ====================

    [Signal] 
    // Signals that the language has been updated
    public delegate void UpdateLanguageEventHandler();


    // ==================== Persistent fields ====================

    // Current language
    private Language Lang;

    // Inventories
    private List<Inventory> InventoryList;

    // ==================== Local Methods ====================

    // Finds the inventory with the apropriate name
    // Creates a new one if necessary
    private int FindInventory(string ReqName) {
        int index = InventoryList.FindIndex(x => x.Name == ReqName);

        if(index < 0) {
            // New inventory
            Inventory newInventory = new Inventory(ReqName);
            InventoryList.Add(newInventory);

            index = InventoryList.Count;
        }

        return index;
    }

    // Adds Item to specified Inventory.
    // Returns true if successful, false if not.
    private bool AddItem(int inventoryIndex, Item newItem, int count) {

        // Sort by slot position
        var orderedByPosition = InventoryList[inventoryIndex].Contents
            .Select((slot, idx) => (slot, idx))
            .OrderBy(sloti => sloti.slot.position).ToList();

        // Find list of the all valid slots containing newItem
        var filteredList = orderedByPosition.Where(sloti =>
                sloti.slot.item.name == newItem.name &&
                sloti.slot.count + count <= newItem.stackSize
            ).ToList();

        if(filteredList.Any()) {
            // Add items to slot
            InventoryList[inventoryIndex].UpdateCount(filteredList[0].idx, count);

        } else {
            // New inventory slot:
            // Fail if all slots are used
            if (InventoryList[inventoryIndex].Contents.Count >= InventoryList[inventoryIndex].MaxSize) {
                return false;
            }

            // To find first empty slot, iterate through sorted list by slot position.
            // For the first position that doesn't correspond to the loop counter, the loop
            // counter gives the position.
            int newPosition = -1;
            for(int i = 0; i < InventoryList[inventoryIndex].Contents.Count; i++) {
                if (orderedByPosition[i].slot.position != i) {
                    newPosition = i; 
                    break;
                }
            }

            InventoryList[inventoryIndex].Contents.Add(new(newItem,newPosition,count));
        }
        return true;
    }

    // ==================== GODOT Method Overrides ====================

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Lang = new(Language.Type.EN);
	}   

    // ==================== Public API ====================

    // Getters and Setters for the language
    public Language _GetLanguage() => Lang;
    public void _SetLanguage(Language L) {
        Lang = L;
    }

    // Inventory Interactions
    public bool _AddItem(string Name, Item newItem, int Position, int count = 1)
    {
        int inventoryIndex;

        inventoryIndex = FindInventory(Name);

        return AddItem(inventoryIndex, newItem, count);
    }

}