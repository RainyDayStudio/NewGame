using Godot;
using System;

// A simple interactable book
public partial class Book : Node2D, Interactable {

	// ==================== Children Nodes ====================

	// Sprite that indicates what button to press
	private Sprite2D E;

	// ==================== GODOT Method Overrides ====================

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// Fetch children
		E = GetNode<Sprite2D>("E");

		// Initially hide the overlay
		E.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}

	// ==================== Interactable interface implements ====================

	// A book interaction simply hides the book for now
    public void Interact() {
        Hide();
    }

	// Entering the book's range will show a E overlay
    public void EnterInteractRange() {
        E.Show();
    }

	// On exit, hide the E overlay again
    public void ExitInteractRange() {
        E.Hide();
    }
}
