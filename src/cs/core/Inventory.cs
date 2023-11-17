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
using System.Diagnostics;

// Models the player's inventory
public partial class Inventory : Node2D {

	// ==================== Inventory Definitions=================
	// Number of inventory slots
	const int INVENTORY_SIZE = 3*7;

	// ==================== Inventory Signals ====================

	// ==================== Inventory Exports ====================

	// ==================== Children Nodes =======================
	// The Inventory's sprite (i.e. visual element)
	private Sprite2D Background;

	// Enables the use of input
	private InputManager IM;

	// ==================== Internal fields ====================
	// Stores the actual inventory
	private int[] InventoryArray = new int[INVENTORY_SIZE];

	// ==================== GODOT Method Overrides ====================
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch the children nodes
		Background = GetNode<Sprite2D>("Background");
		IM = GetNode<InputManager>("InputManager");

        // Debug: Start with non-empty inventory
        
	}

	// Called at the start of every frame
	public override void _Process(double delta) {
		HandleCursor();
	}

	// ==================== Internal Helpers ====================
	// Handles cursor interaction
	private void HandleCursor() {
		// Check the input manager for open inventory input
		/*
		if(IM._CheckInventoryInput()) {
			// Change Player State
			if(State == PlayerState.BLOCKED)
				State = PlayerState.IDLE;
			else State = PlayerState.BLOCKED;

			// Show/Hide UI
			Inventory.Visible = !Inventory.Visible;
		}*/
	}
}

