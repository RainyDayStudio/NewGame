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
using System.Linq;

// Models the player's inventory
public partial class ItemManager : Node {

	// ==================== Internal fields ====================
	// File for item DB
    private const string ItemDBFile = "items.xml";

	// Item DB
	private ItemController IC;

	// ==================== GODOT Method Overrides ====================
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

	}


 	// ==================== Local Methods ====================



	// ==================== Public API ====================

	// Adds Item to inventory by name
	public Item GetItem(string itemName, int count) {
		return IC.GetItem(ItemDBFile, itemName);
	}

	public string GetSprite(string itemName) {
		return IC.GetItemSprite(ItemDBFile, itemName);
	}
	
}

