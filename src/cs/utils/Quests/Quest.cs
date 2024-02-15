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

	// =================================================
	// ================ Utilitary types ================
	// =================================================

/// <summary>
/// Represents the type of quests' objectives
/// ORDERED: all objectives must be completed in ID ascending order
/// UNORDERED: objectives can be completed in any order
/// </summary>
public enum ObjectiveType {
	ORDERED, UNORDERED
}

/// <summary>
/// Represents a quest's type
/// MAIN: main quests are mandatory
/// SIDE: player can choose to accept side quests or not 
/// </summary>
public enum QuestType {
	MAIN, SIDE
}

// Represents a game quest
public class Quest: Prerequisit {


	// ================ Quest fields ================

	// Quest's unique identifier
	private string ID;

	// Quest's objective type (can either be ordered or unordered)
	private ObjectiveType ObjType;

	// Quest's type
	// Can either be a main (mandatory) or a side (optional) quest
	private QuestType Type;

	// List of all the quest's objectives
	private List<Objective> Objectives;
	

    // ==================== Public API ====================

    // Getters and Setters
    public string _GetID() => ID;
    public void _SetID(string QuestID) {
        ID = QuestID;
    }

	// ============== Prerequisit interace implements ==============

    /// <summary>
    /// Checks if all the quest's objectives have been completed
	/// and checks their order when necessary
    /// </summary>
    /// <returns>True if quest completed</returns>
	public bool _Satisfied() {
		// TODO: call _Completed on all objectives and check order if necessary
		// if(ObjType.Equals(ORDERED)) {

		// }

		for(int i = 0; i < Objectives.Count; ++i) {
			if(!Objectives[i]._Completed()) {
				// If at least one objective is incomplete,
				// the quest cannot be satisfied
				return false;
			}
		}
        return true;
    }
}

} // End Godot namespace
