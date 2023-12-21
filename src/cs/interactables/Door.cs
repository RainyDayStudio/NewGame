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

// Represents a door in the game. Doors are the way the player can travel
// From one scene to the next in the fame.
public partial class Door : Node2D, Interactable {
	//  ==================== Exports ====================
	[Export]
	// The scene to which this door will send us
	public string TargetScenePath;

	// ==================== Children Nodes ====================

	// Sprite that indicates what button to press
	private Sprite2D E;
	
	// Handles the scene switching
	private SceneManager SM;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch children
		E = GetNode<Sprite2D>("E");
		SM = GetNode<SceneManager>("/root/SceneManager");

		E.Hide();
	}

	// ==================== Interactable interface implements ====================

	// A door will send you to another scene when opened
    public bool Interact() {
        // Switch Scenes
		SM.GotoScene("res://scenes/" + TargetScenePath + ".tscn");
		return true;
    }

	// Simply show the interaction prompt
    public void EnterInteractRange() {
        E.Show();
    }

	// Hide the interaction prompt
    public void ExitInteractRange() {
        E.Hide();
    }
}
