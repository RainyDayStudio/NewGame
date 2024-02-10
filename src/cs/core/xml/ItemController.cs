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
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

// Utility class used to access XML db files.
// This handles all data related to items.
public partial class ItemController : XMLController {

	// ==================== Dialog related Constants ====================

	private const string DB_ID = "items";
	private const string ITEM_ID = "item";
	private const string ITEM_TYPE = "type";
	private const string ITEM_NAME_ID = "name";
	private const string INGREDIENT_ID = "ingredient";
	private const string INGREDIENT_NAME_ID = "name";
	private const string INGREDIENT_AMOUNT_ID = "amount";
	private const string INGREDIENT_VOLUME_ID = "volume";
	// ==================== Internal fields ====================

	// The currently loaded xml document
	private XDocument LoadedXML;
	private string LoadedFileName;

    // ==================== Internal Helpers ====================
    private void CheckXML(string filename) {
        // Check if the file is loaded in or not
        if(LoadedFileName != filename) {
            // If not parse the file
            ParseXML(ref LoadedXML, Path.Combine(DB_ID, filename));

            // Update the current loaded file data
            LoadedFileName = filename;
        }
    }

	// ==================== Public API ====================
    // Returns Item Object from Item name
    public Item GetItem(string filename, string name) {
        Item newItem;
        int stackSize;

        CheckXML(filename);

        // Find Item with correct name
        var query = from g in LoadedXML.Root.Descendants(ITEM_ID)
					where g.Attribute(ITEM_NAME_ID).Value == name // Find the correct Item
                    select g.Element("stack");

        string stackStr = query.ElementAt(0).Value;

        try {
            stackSize = Int32.Parse(stackStr);
        } catch(Exception) {
			// Control what error is displayed for better debugging
			throw new Exception("Could not Parse: " + stackStr);
		}

        newItem.name = name;
        newItem.stackSize = stackSize;

        return newItem;
    }

    // Returns Item sprite from Item name
    public string GetItemSprite(string filename, string name) {
        CheckXML(filename);

        // Find Item with correct name
        var query = from g in LoadedXML.Root.Descendants(ITEM_ID)
					where g.Attribute(ITEM_NAME_ID).Value == name // Find the correct Item
                    select g.Element("sprite");

        return query.ElementAt(0).Value;
    }
}
