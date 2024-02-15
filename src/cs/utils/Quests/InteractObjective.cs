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
/// Represents an interaction objective
/// The player must have interacted with a specific target
/// to complete the objective
/// </summary>
public class InteractObjective: Objective {


	// ================ Objective fields ================

	// Target's unique identifier (NPC, item, ...)
	private string Target;
	

    // ==================== Public API ====================

	// Basic constructor
	public InteractObjective(string TargetID) {
		Target = TargetID;
	}

    // Getters and Setters
    public string _GetTarget() => Target;

    public void _SetTarget(string T) {
        Target = T;
    }

	// ============== Prerequisit interace implements ==============

    /// <summary>
    /// Checks if the player interacted with the target
    /// </summary>
    /// <returns>True if objective completed</returns>
	public bool _Completed() {
		// TODO: check if the player interacted with the target
        return true;
    }
}

} // End Godot namespace
