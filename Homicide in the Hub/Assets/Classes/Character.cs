using UnityEngine;
using System.Collections;

abstract public class Character {
	private string characterID;
	private Sprite sprite;
	private string nickname;

	protected Character(string characterID, Sprite sprite, string nickname) {
		this.characterID = characterID;
		this.sprite = sprite;
		this.nickname = nickname;
	}

	public string getCharacterID(){
		return this.characterID;
	}

	public Sprite getSprite(){
		return this.sprite;
	}

	public string getNickname(){
		return this.nickname;
	}
}
