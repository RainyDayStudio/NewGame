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


// Namespace declaration necessary for utility types
namespace Godot {


/// <summary>
/// Represents an action objective
/// The player must have performed a specific action
/// to complete the objective
/// </summary>
public class ActionObjective: Objective {


	// ================ Objective fields ================

	// Action's unique identifier (e.g. a spell name, sleep, consume, ...)
	private string ID;

	// Represents the state of the action (default is: not performed)
	// Will be updated as soon as the action has been performed
	private bool Performed;
	

    // ==================== Public API ====================

	// Basic constructor
	public ActionObjective(string ActionID) {
		ID = ActionID;
		Performed = false;
	}

    // Getters and Setters
    public string _GetID() => ID;

    public void _SetID(string ActionID) {
        ID = ActionID;
    }

	// Sets the action as performed
	// Called as soon as the action has been performed
    public void _SetPerformed() {
        Performed = true;
    }

	// ============== Prerequisit interace implements ==============

    /// <summary>
    /// Checks if the player performed the action
    /// </summary>
    /// <returns>True if objective completed</returns>
	public bool _Completed() {
        return Performed;
    }
}

} // End Godot namespace
