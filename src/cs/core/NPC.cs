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

// Models a generic Non-Playable Character
// These characters are interactable and can have dialog
public partial class NPC : CharacterBody2D, Interactable {

	// ==================== Children Nodes ====================
	// Used to display the npc's image
	private Sprite2D Sprite;

	// ==================== GODOT Method Overrides ====================
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch the children nodes
		Sprite = GetNode<Sprite2D>("Sprite");
	}

	// Called at the start of every frame
	public override void _Process(double delta) {}

	// ==================== Interactable interface methods ====================
    public void EnterInteractRange() {
        throw new NotImplementedException();
    }

    public void ExitInteractRange() {
        throw new NotImplementedException();
    }

    public void Interact() {
        throw new NotImplementedException();
    }
}
