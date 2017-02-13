using UnityEngine;
using System.Collections;

abstract public class Character {
	//Abstract class used to define the variables and methods used by PlayerCharacter and NonPlayerCharacter

	//__Variables__
	private string characterID; //Holds The characters name (used for reference and comparisons)
	private Sprite sprite; 		//Holds the image of the character
	private string nickname;	//Assigns a nickname to the character.
	private bool canBeAccused = true;

	//__Constructor__
	protected Character(string characterID, Sprite sprite, string nickname) {
		this.characterID = characterID;
		this.sprite = sprite;
		this.nickname = nickname;
	}

	//Accessors 
	public string getCharacterID(){
		return this.characterID;
	}

	public Sprite getSprite(){
		return this.sprite;
	}

	public string getNickname(){
		return this.nickname;
	}

	public bool CanBeAccused(){
		return this.canBeAccused;
	}

	public void BlockCharacterQuestioning(){
		this.canBeAccused = false;
	}

	public void AllowCharacterQuestioning(){
		this.canBeAccused = true;
	}
}
