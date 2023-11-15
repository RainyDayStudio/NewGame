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

// Handles displaying and updating dialog from any entity that parents this node
public partial class DialogManager : Node2D {

	// ==================== Children Nodes ====================

	// Background containing the text 
	private Sprite2D TextBox;
	// Text label itself. This will contain the dialog
	private Label Body;
	// Interaction prompt shown when the player can continue the text
	private Sprite2D E;
	// Handles reading and querying xml dialog files
	private TextController TC;

	// ==================== Internal fields ====================

	// Keeps track of the current dialog index
	private int DialogIdx = 0;

	// Keeps track of the current max dialog
	private int DialogMaxIdx = 0;

	// Keeps track whether or not dialog is ongoing
	private bool DialogActive = false;

	// Keeps track of the current loaded ID
	private string DialogID = "";

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch children nodes
		TextBox = GetNode<Sprite2D>("TextBoxBG");
		Body = GetNode<Label>("TextBoxBG/Body");
		E = GetNode<Sprite2D>("TextBoxBG/E");
		TC = GetNode<TextController>("TextController");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}

	// ==================== Public API ====================

	// Reacts to a dialog interaction 
	// This will start a new dialog if none is loaded
	// If one is loaded it will go to the next one until the max is hit
	// @param {filename} the file the dialog is being loaded from
	// @param {id} the id of the dialog that should be advanced
	// @returns Whether or not the interaction has ended
	public bool _NextDialog(string filename, string id) {
		// We check if a dialog is ongoing, if so the id should be the same as the ongoing one
		if(DialogActive) {
			Debug.Assert(DialogID == id);

			// Retrieve the text from the xml file
			string text = TC._GetText(filename, id, DialogIdx.ToString());

			// Display it (no size check because flemme)
			Body.Text = text;

			// Increment the index and check that it doesn't overflow
			if(++DialogIdx == DialogMaxIdx) {
				// End the dialog
				EndDialog();

				// Notify that the dialog has ended
				return false;
			}
			// Show the E button to signal that an interaction is expected
			E.Show();

			// Notify that an interaction needs to happen
			return true;
		}

		// In this case we should start a new dialog
		StartDialog(filename, id);
		return true;
	} 

	// ==================== Internal Helpers ====================

	// Ends the current dialog
	private void EndDialog() {
		// End the dialog
		DialogActive = false;
		DialogIdx = 0;
		DialogMaxIdx = 0;

		// Hide the dialog box
		TextBox.Hide();
		E.Hide();
	}

	// Starts a dialog, fetching the first text and storing all necessary values
	private void StartDialog(string filename, string id) {
		// The max id must be set to the total amount of text elements in the node
		DialogMaxIdx = TC._GetNTexts(filename, id);

		// Reset all counters and save id
		DialogIdx = 0;
		DialogActive = true;
		DialogID = id;

		// Show UI elements
		TextBox.Show();
		
		// Check for E button: show it if we can continue our dialog
		if(DialogMaxIdx > 1) {
			E.Show();
		}

		// Fetch the first text and start our counter
		Body.Text = TC._GetText(filename, id, DialogIdx.ToString());
		DialogIdx++;
	}

}
