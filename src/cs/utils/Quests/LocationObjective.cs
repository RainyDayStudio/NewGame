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
/// Represents a location objective
/// The player needs to be at a specific location to complete an objective
/// </summary>
public class LocationObjective: Objective {


	// ================ Objective fields ================

	// Location's unique identifier
	private string ID;
	

    // ==================== Public API ====================

	// Basic constructor
	public LocationObjective(string LocID) {
		ID = LocID;
	}

    // Getters and Setters
    public string _GetID() => ID;

    public void _SetID(string LocationID) {
        ID = LocationID;
    }

	// ============== Prerequisit interace implements ==============

    /// <summary>
    /// Checks if the player is at the objective's location
    /// </summary>
    /// <returns>True if objective completed</returns>
	public bool _Completed() {
		// TODO: check if the player is at the location
        return true;
    }
}

} // End Godot namespace
