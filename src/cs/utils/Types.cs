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
	// @returns whether or not the interaction has ended
	public bool Interact();

	// Triggers a reaction when an interactor enters the interaction range
	public void EnterInteractRange();

	// Triggers a reaction when an interactor exits the interaction range
	public void ExitInteractRange();
}

// Item type used in inventories
public struct Item {
	public string name;
	public int stackSize;
}

// Inventory slot
public struct InventorySlot {
	public Item item;
	public int count;
	public int position;

	// Basic constructor, item is mandatory because a null Item InventorySlot
	// shouldn't exist
	public InventorySlot(Item item, int position = 0, int count = 1) { 
		this.item = item;
		this.position = position;
		this.count = count;
	}

	// Increment or decrement the amount of items in this slot
    public void UpdateCount(int deltaCount) {
        count += deltaCount;
    }
}

// Inventory definition
public struct Inventory {
    public string Name;
	public List<InventorySlot> Contents;
	public int MaxSize;

	// Constructor for Inventory, requires name for identification
    public Inventory(string newName, int InventorySize = 21) {
        Name = newName;
        Contents = new();
		MaxSize = InventorySize;
    }
        
	// Update the amount of items in slot slotIndex
	// parameter count can be positive or negative
	public void UpdateCount(int slotIndex, int count) {
		Contents[slotIndex].UpdateCount(count);
	}
}

// Fancy enum that models the languages available for the game
    public readonly struct Language {
	// Represents the different types of languages
	public enum Type { EN, FR, DE, IT };

	// Internal storage of a language
	public readonly Type lang;

	// Basic constructor for the language
	public Language(Type l)  {
		lang = l;
	}

	// Override equality and inequality operators
	public static bool operator ==(Language l, Language other) => l.lang == other.lang;
	public static bool operator !=(Language l, Language other) => l.lang != other.lang;

	// Override the incrementation and decrementation operators
	public static Language operator ++(Language l) => new Language((Type)((int)(l.lang + 1) % (int)(Type.IT + 1)));
	public static Language operator --(Language l) => new Language((Type)((int)(l.lang - 1) % (int)(Type.IT + 1)));

	// Implicit conversion from the enum to the struct
	public static implicit operator Language(Type lt) => new Language(lt);

	// Implicit conversion from the struct to the enum
	public static implicit operator Type(Language l) => l.lang;

	// Implicit conversion from a string to a language
	public static implicit operator Language(string s) {
		// Make it as easy to parse as possible
		string s_ = s.ToLower().StripEdges();
		if(s == "en" || s == "english") {
			return new Language(Type.EN);
		} 
		if (s == "fr" || s == "french" || s == "français") {
			return new Language(Type.FR);
		} 
		if(s == "de" || s == "german" || s == "deutsch") {
			return new Language(Type.DE);
		} 
		return new Language(Type.IT);
	}
	
	// Implicit conversion to a string
	public override string ToString() => lang == Type.EN ? "en" : 
										lang == Type.FR ? "fr" :
										lang == Type.DE ? "de" :
										"it";

	// Converts the language to a human-readable format
	public string ToName() => lang == Type.EN ? "Language: English" : 
							lang == Type.FR ? "Langue: Français" :
							lang == Type.DE ? "Sprache: Deutsch" :
							"Lingua: Italiano";

	// Performs the same check as the == operator, but with a run-time check on the type
	public override bool Equals(object obj) {
		// Check for null and compare run-time types.
		if ((obj == null) || ! this.GetType().Equals(obj.GetType())) {
			return false;
		}
		// Perform actual equality check
		return lang == ((Language)obj).lang;
	}

	// Override of the get hashcode method (needed to overload == and !=)
	public override int GetHashCode() => HashCode.Combine(lang);
}
} // End Godot namespace
