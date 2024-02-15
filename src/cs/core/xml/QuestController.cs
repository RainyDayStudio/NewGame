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
public partial class QuestController : XMLController {

	// ==================== Dialog related Constants ====================

	private const string QUEST_ID = "quest";
	private const string PREREQ_ID = "prereq";
	private const string OBJECTIVE_ID = "objective";
	private const string REWARD_ID = "reward";
	private const string ID = "id";
	private const string OBJ_TYPE = "obj-type";
	private const string TYPE = "type";

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

	  // Updates the language the Questcontroller is set to  
	public void _UpdateLanguage() {
		// Check that the given language is new
		if(C._GetLanguage() != Lang) {
			Lang = C._GetLanguage();
			
			// Update the loaded xml
			ParseXML(ref LoadedXML, Path.Combine(QUEST_ID, Lang.ToString() + "/" + LoadedFileName));
		}
	}

	// Retrieves the type of objectives
	public string _GetObjectiveType(string filename, string questid) {
		// Start by checking if the file is loaded in or not
		CheckXML(filename);

		return (
			from q in LoadedXML.Root.Descendants(QUEST_ID)
			where q.Attribute(ID).Value == questid
			select q.Attribute(OBJ_TYPE).Value).ElementAt(0);
	}

	// Retrieves the quest type
	public string _GetQuestType(string filename, string questid) {
		// Start by checking if the file is loaded in or not
		CheckXML(filename);

		return (
			from q in LoadedXML.Root.Descendants(QUEST_ID)
			where q.Attribute(ID).Value == questid
			select q.Attribute(TYPE).Value).ElementAt(0);
	}
	
	// Retrieves all quest's prerequisits
	public string _GetPrereqs(string filename, string questid) {
		// Start by checking if the file is loaded in or not
		CheckXML(filename);

		IEnumerable<XElement> quest =
			from q in LoadedXML.Root.Descendants(QUEST_ID)
			where q.Attribute(ID).Value == questid
			select q;

		// return quest.Descendants("prereq").Select(p => )
		// TODO
		return "";
	}
	
	// Retrieves all quest's objectives
	public List<Objective> _GetObjectives(string filename, string questid) {
		// Start by checking if the file is loaded in or not
		CheckXML(filename);

		IEnumerable<XElement> quest =
			from q in LoadedXML.Root.Descendants(QUEST_ID)
			where q.Attribute(ID).Value == questid
			select q;

		return quest.Descendants("objective").Select(
			o => (Objective) new ItemObjective(
				o.Attribute("id").Value,
				o.Attribute("amount").Value.ToInt()
			)).ToList();
	}

	// ==================== Internal Helpers ====================

	// Checks that the requested xml file is loaded
	private void CheckXML(string filename) {
		// Check if the file is loaded in or not
		if(LoadedFileName != filename || LoadedLanguage != Lang) {
			// If not parse the file
			ParseXML(ref LoadedXML, Path.Combine(QUEST_ID, Lang.ToString() + "/" + filename));

			// Update the current loaded file data
			LoadedFileName = filename;
			LoadedLanguage = Lang;
		}
	}
}
