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

namespace Godot {
// Generic Node that enables it's owner to receive user input
// The basic capabilities it enables are movement
public partial class InputManager : Node {

	// ==================== Children Nodes ====================
	// The node the manager is tasked with updating
	private Node2D Managee; 

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch Children Nodes
		Managee = GetOwner<Node2D>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	// ==================== Public API ====================

	// Returns the current value of the input vector
	// @param {bool}, wether or not the owner is in a moveable state
	// e.g. if the owner is in a dialog, then they can't move
	// @returns {Vector2, bool} the input vector along with a runrequest flag
	public (Vector2, bool) _GetInputVec(bool canMove) {
		Vector2 InputVec = Vector2.Zero;
		bool RunRequest = false;

		// Only update the input vector if movement is allowed
		if(canMove) {
			//Handle movement
			InputVec.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
			InputVec.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
			InputVec = InputVec.Normalized();

			// Check for a sprint request
			RunRequest = Input.IsActionPressed("ui_shift");
		} 

		return (InputVec, RunRequest);
	}

	// Returns wether or not interaction has been requested
	// @param {bool}, interaction enabler
	public bool _CheckInteractionInput(bool canInteract=true) =>
		canInteract && Input.IsActionJustPressed("ui_interact");

	// Returns wether or not inventory has been requested
	// @param {bool}, inventory enabler
	public bool _CheckInventoryInput(bool canOpen=true) =>
		canOpen && Input.IsActionJustPressed("ui_inventory");
}
} // End Namespace Godot
