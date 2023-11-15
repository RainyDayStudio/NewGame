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

// Base class for all controllers that work with xml objects
public abstract partial class XMLController : Node {

    // ==================== XML related constants ====================

	// The path to the base of the db 
	protected const string DB_PATH = "db/";

	// ==================== XML Generic methods ====================

	// Parses a given xml file and stores in in a target XDocument object
	// The filename should include the relative path from db/
	protected void ParseXML(ref XDocument targetXML, string filename) {
		if(filename == null) {
			throw new Exception("No xml file was input for the scene!");
		}
		
		//Load XML file into a XDocument for querying
		string loadedXML;
		XDocument xml;
		string path = DB_PATH + filename;
		try { 
			loadedXML = File.ReadAllText(path);
			xml = XDocument.Parse(loadedXML);
		} catch(Exception) {
			// Control what error is displayed for better debugging
			throw new Exception("File not found: " + path);
		}
		
		//Sanity check: The loaded xml shouldn't be empty
		if(xml != null) {
			targetXML = xml;
		} else {
			throw new Exception("Unable to load xml file: " + filename);
		}
	}
}