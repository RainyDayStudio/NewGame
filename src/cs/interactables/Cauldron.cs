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
using System.Collections.Generic;

// An interactible potion crafting station
public partial class Cauldron : Node2D, Interactable {

	// ==================== Children Nodes ====================

	// Sprite that indicates what button to press
	private Sprite2D E;

    // ==================== Internal fields ====================
	// Stores the Cauldron's current state
	private List<int> Ingredients;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch children
		E = GetNode<Sprite2D>("E");

		// Initially hide the overlay
		E.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}

	// ==================== Interactable interface implements ====================

	// A book interaction simply hides the book for now
	public bool Interact() {
		//Open UI
		return true;
	}

	// Entering the book's range will show a E overlay
	public void EnterInteractRange() {
		E.Show();
	}

	// On exit, hide the E overlay again
	public void ExitInteractRange() {
		E.Hide();
	}
}
