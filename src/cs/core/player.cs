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
public partial class Player : CharacterBody2D {

    // ==================== Player specific enums ====================
    // Models the different states the player may be in
    private enum PlayerState {
        IDLE, // The player isn't moving
        WALKING, // The player is moving at a slow pace
        RUNNING, // The player is moving at an accelerated pace
        BLOCKED, // The player can't move (because of an active interaction or open menu)
    };

    // ==================== Player Signals ====================

    // ==================== Player Exports ====================
    [ExportGroup("Movement Parameters")]
    [Export]
    // Describes how fast the player's run speed is
    private int RunSpeed = 150;

    [Export]
    // Describes how fast the player's walk speed is
    private int WalkSpeed = 100;

    [Export]
    // How quickly the player stops
    private int Friction = 1000;

    [Export]
    // How quickly the player accelerates
    private int Acceleration = 950;

    // ==================== Children Nodes ====================
    // The player's sprite (i.e. visual element)
    private Sprite2D Sprite;

    // The Animation player (used to activate certain animations)
    private AnimationPlayer AP;

    // The Animation Tree (used to create a set of transitions between animations)
    private AnimationTree AT;

    // The hitbox (used for collisions)
    private CollisionShape2D Hitbox;

    // Enables the use of input
    private InputManager IM;

    // ==================== Internal fields ====================
    // Stores the players current state
    private PlayerState State = PlayerState.IDLE;

    // ==================== GODOT Method Overrides ====================
    // Called when the node enters the scene tree for the first time.
	public override void _Ready() {
        // Fetch the children nodes
        Sprite = GetNode<Sprite2D>("Sprite");
        AP = GetNode<AnimationPlayer>("AnimationPlayer");
        AT = GetNode<AnimationTree>("AnimationTree");
        Hitbox = GetNode<CollisionShape2D>("Hitbox");
        IM = GetNode<InputManager>("InputManager");
    }

    // Called at the start of every frame
    public override void _Process(double delta){
        base._Process(delta);

        // Handle the player's movement
        HandleMovement(delta);
    }

    // ==================== Internal Helpers ====================
    // Handles the movement of the player
    // Inputs are generally handled via polling on every frame
    private void HandleMovement(double delta) {
        // Retrieve the user's input
        (Vector2 InputVec, bool RunRequest) = IM._GetInputVec(State != PlayerState.BLOCKED);

        // Figure out how fast we want our player to go
        int Speed = RunRequest ? RunSpeed : WalkSpeed;
		
		// Update the velocity based on the input vector
        // If InputVec is Zero, then the player should stop moving
		if(InputVec == Vector2.Zero) {
            // Note that Velocity is a built-in field of the CharacterBody2D class
			Velocity = Velocity.MoveToward(Vector2.Zero, (float)(Friction * delta));
		} else {
            // TODO: Set blend positions for animation tree

            // Update the movement velocity s.t. it moves towards the requested speed
		    Velocity = Velocity.MoveToward(InputVec * Speed, (float)(Acceleration * delta));
		}

        // Move the player using the built-in move&slide method for character bodies
        MoveAndSlide();
    }
}

