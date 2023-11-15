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
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

// Utility class used to access XML db files.
// This is usually done to display text in a way that is linguistically dynamic .
public partial class TextController : XMLController {

    // ==================== Internal fields ====================

	// The currently loaded xml document
	private XDocument LoadedXML;
	private string LoadedFileName;
	private Language LoadedLanguage;

	// The current language
	private Language Lang = Language.Type.EN;

	// Context
	private Context C;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch Context
		C = GetNode<Context>("/root/Context");

		// Connect to the context's update language signal
		C.UpdateLanguage += _UpdateLanguage;
	}

	// ==================== Public API ====================

	  // Updates the language the textcontroller is set to  
	public void _UpdateLanguage() {
		// Check that the given language is new
		if(C._GetLanguage() != Lang) {
			Lang = C._GetLanguage();
			
			// Update the loaded xml
			ParseXML(ref LoadedXML, Path.Combine("text", Lang.ToString() + "/" + LoadedFileName));
		}
	}

	// Retrieves the number of texts in a group
	public int _GetNTexts(string filename, string groupid) {
		// Start by checking if the file is loaded in or not
		CheckXML(filename);

		// retrieve the number of elements in the given group
		IEnumerable<int> n_texts = from g in LoadedXML.Root.Descendants("group")
					where g.Attribute("id").Value == groupid
					select g.Descendants("text").Count();
		
		// Extract the result and return it
		return n_texts.ElementAt(0);
	}

	// Queries the given xml file to retrieve the wanted text
	public string _GetText(string filename, string groupid, string id) {
		// Start by checking if the file is loaded in or not
		CheckXML(filename);

		// Query the file
		var query = from g in LoadedXML.Root.Descendants("group")
					where g.Attribute("id").Value == groupid // Find the correct group
					select (
						from t in g.Descendants("text")
						where t.Attribute("id").Value == id // Find the correct text in the group
						select t.Value
					);

		// Extract query result
		return query.ElementAt(0).ElementAt(0);
	}

	// ==================== Internal Helpers ====================

	// Checks that the requested xml file is loaded
	private void CheckXML(string filename) {
		// Check if the file is loaded in or not
		if(LoadedFileName != filename || LoadedLanguage != Lang) {
			// If not parse the file
			ParseXML(ref LoadedXML, Path.Combine("text", Lang.ToString() + "/" + filename));

			// Update the current loaded file data
			LoadedFileName = filename;
			LoadedLanguage = Lang;
		}
	}
}