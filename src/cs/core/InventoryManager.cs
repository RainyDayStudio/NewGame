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

// Models the player's inventory
public partial class InventoryManager : Node2D {

	// ==================== Inventory Definitions=================

	// ==================== Inventory Signals ====================

	// ==================== Inventory Exports ====================
	// Number of inventory slots
	[Export]
	int InventorySize = 3*7;

	// ==================== Children Nodes =======================
	// The Inventory's sprite (i.e. visual element)
	private Sprite2D Background;

	// ==================== Internal fields ====================
	// Stores the actual inventory
	private bool isOpen;

	// ==================== GODOT Method Overrides ====================
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch the children nodes
		Background = GetNode<Sprite2D>("Background");

        // Initialize internal fields
        //inventory = new Inventory(InventorySize);
		isOpen = false;
	}

	// Called at the start of every frame
	public override void _Process(double delta) {
	}

	// Called when inventory is opened
	public void Open() {
		Background.Show();
		isOpen = true;
	}

	// Called when inventory is closed
	public void Close() {
		Background.Hide();
		isOpen = false;
	}

	public bool IsOpen {
		get { return isOpen; }
	}
}

