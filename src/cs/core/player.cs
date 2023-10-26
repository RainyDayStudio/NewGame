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

// Models the player, i.e. the user's entry point into the game
// This will handle all inputs as well as their related character animations
// We will also be managing the general interaction logic here
// @dev-note: All other gameplay elements should be handled through encapsulation and 
//      not directly in the player itself, e.g. the magic should be handled in a separate 
//      MagicHandler class which will become a child node of this class.
public partial class Player : Node2D {

    // ==================== Children Nodes ====================
    // The player's sprite (i.e. visual element)
    private Sprite2D Sprite;

    // The Animation player (used to activate certain animations)
    private AnimationPlayer AP;

    // The Animation Tree (used to create a set of transitions between animations)
    private AnimationTree AT;

    // The hitbox (used for collisions)
    private CollisionShape2D Hitbox;

    // ==================== GODOT Method Overrides ====================
    // Called when the node enters the scene tree for the first time.
	public override void _Ready() {
        // Fetch the children nodes
        Sprite = GetNode<Sprite2D>("Sprite");
        AP = GetNode<AnimationPlayer>("AnimationPlayer");
        AT = GetNode<AnimationTree>("AnimationTree");
        Hitbox = GetNode<CollisionShape2D>("Hitbox");
    }

    // Called at the start of every frame
	public override void _Process(float delta) {
    }
}
