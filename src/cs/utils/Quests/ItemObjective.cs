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
/// Represents an item objective
/// The player needs to have a specific item in their inventory
/// to complete the objective
/// </summary>
public class ItemObjective: Objective {


	// ================ Objective fields ================

	// Item's unique identifier
	private string ID;

	// How many instances of this item are needed to
	// complete the objective (default is 1)
	private int Amount;
	

    // ==================== Public API ====================

	// Basic constructor
	public ItemObjective(string ItemID, int N = 1) {
		ID = ItemID;
		Amount = N;
	}

    // Getters and Setters
    public string _GetID() => ID;

    public void _SetID(string ObjID) {
        ID = ObjID;
    }

    public int _GetAmount() => Amount;

    public void _SetAmount(int N) {
        Amount = N;
    }

	// ============== Prerequisit interace implements ==============

    /// <summary>
    /// Checks if the player has the right amount of the item
	/// in their inventory
    /// </summary>
    /// <returns>True if objective completed</returns>
	public bool _Completed() {
		// TODO: check if the player has the item in their inventory
        return true;
    }
}

} // End Godot namespace