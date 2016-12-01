using UnityEngine;
using System.Collections;

public class NonPlayerCharacter : Character {

	private bool isMurderer = false; 
	// Use this for initialization

	public NonPlayerCharacter (string characterID, Sprite sprite, string nickname) :  base(characterID, sprite, nickname) {
	}

	public bool IsMurderer(){
		return this.isMurderer;
	}

	public void SetAsMurderer(){
		this.isMurderer = true;
	}
}
