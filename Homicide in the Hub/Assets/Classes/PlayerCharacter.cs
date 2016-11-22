using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {
	private Vector2 locationInScene;
	private string currentScene;
	public PlayerCharacter(Vector2 _locationInScene){
		locationInScene = _locationInScene;
	}

}
