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

// Handles displaying and updating dialog from any entity that parents this node
public partial class DialogManager : Node2D {

	// ==================== Children Nodes ====================

	// Background containing the text 
	private Sprite2D TextBox;
	// Text label itself. This will contain the dialog
	private Label Body;
	// Interaction prompt shown when the player can continue the text
	private Sprite2D E;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch children nodes
		TextBox = GetNode<Sprite2D>("TextBoxBG");
		Body = GetNode<Label>("TextBoxBG/Body");
		E = GetNode<Sprite2D>("TextBoxBG/E");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}

	// ==================== Public API ====================
}
