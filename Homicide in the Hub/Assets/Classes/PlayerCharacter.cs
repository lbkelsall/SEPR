using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {
	private string questioningStyle;
	private string description;

	public PlayerCharacter(string characterID,Sprite sprite, string nickname,string questioningStyle, string description) :  base(characterID, sprite,nickname) {
		this.questioningStyle = questioningStyle;
		this.description = description;
	}

	public string getQuestioningStyle(){
		return this.questioningStyle;
	}

	public string getDescription(){
		return this.description;
	}
}
