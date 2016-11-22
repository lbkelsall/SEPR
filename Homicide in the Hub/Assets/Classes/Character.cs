using UnityEngine;
using System.Collections;

abstract public class Character {
	private string characterID;
	private Sprite sprite;

	public Character(){
	}

	public string getCharacterID(){
		return this.characterID;
	}
}
