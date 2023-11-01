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

// Models an object that can be interacted with
public partial class Interactable : Node2D {

	// ==================== Children Nodes ====================

	// Area in which this object can be interacted with
	private Area2D InteractionArea;

	// ==================== Internal fields ====================

	// List of areas that this interactable is listining to
	// This means that it will react to any interaction request by these subs
	private List<Interactable> Subs;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch children nodes
		InteractionArea = GetNode<Area2D>("InteractionArea");

		// Initialize fields
		Subs = new ();

		// Connect signals
		InteractionArea.AreaEntered += OnInteractionAreaEntered;
		InteractionArea.AreaExited += OnInteractionAreaExited;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		// Poll for interaction
		HandleInteraction();
	}

	// ==================== Internal Helpers ====================

	// Manages checking whether interaction has been requested or not
	private void HandleInteraction() {
		// Check for interaction input
		if(Input.IsActionPressed("ui_interact")) {
			// Check subs find the closest one
		}
	}

	// ==================== Signal Callbacks ====================

	// Reaction to an area2d entering our interaction range
	private void OnInteractionAreaEntered(Area2D other) {
		// Checks if the received area belongs to an interactor we are already listining for
		if(other.Owner is Interactable) {
			// Cast owner into the correct type
			Interactable own = other.Owner as Interactable;

			// Check that it isn't already in our list, if not add it
			if(!Subs.Contains(own)) {
				Subs.Add(own);
			}
		} 
	}

	// Reaction to an area2d existing our interaction range
	private void OnInteractionAreaExited(Area2D other) {
		// Checks if the received area belongs to an interactor we are already listining for
		if(other.Owner is Interactable) {
			// Cast owner into the correct type
			Interactable own = other.Owner as Interactable;

			// Check that it isn't already in our list, if not add it
			if(Subs.Contains(own)) {
				Subs.Remove(own);
			}
		} 
	}
}
