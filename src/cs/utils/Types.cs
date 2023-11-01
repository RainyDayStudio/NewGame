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

// ==================================================
// This file contains all of utility type declarations
// used throughout the project
// ==================================================

// Namespace declaration necessary for utility types
namespace Godot {

    // Abstract interface used to signify that a node2D is an interactor
    public interface Interactable {

        // ==================== Abstract methods ====================

        // Usually a reaction to a button press, this will signify that 
        // the interactor wants to interact with something
        public void Interact();
    }
}