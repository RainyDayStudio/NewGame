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

// Global state of the game
// Records all persistent data for the game
// This is what we would want to serialize in order to save it.
public partial class Context : Node {

    // ==================== Context Signals ====================

    [Signal] 
    // Signals that the language has been updated
    public delegate void UpdateLanguageEventHandler();

    // ==================== Persistent fields ====================

    // Current language
    private Language Lang;

    // ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
        Lang = new(Language.Type.EN);
	}   

    // ==================== Public API ====================

    // Getters and Setters for the language
    public Language _GetLanguage() => Lang;
    public void _SetLanguage(Language L) {
        Lang = L;
    }

}