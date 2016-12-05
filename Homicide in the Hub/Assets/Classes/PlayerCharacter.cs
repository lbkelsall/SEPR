using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {
	private string[] questioningStyles;
	private string description;
	private string overallStyle; 

	public PlayerCharacter(string characterID,Sprite sprite, string nickname,string overallStyle,string[] questioningStyles, string description) :  base(characterID, sprite,nickname) {
		this.questioningStyles = questioningStyles;
		this.overallStyle = overallStyle;
		this.description = description;
	}

	public string[] GetQuestioningStyles(){
		return this.questioningStyles;
	}

	public string GetOverallQuestioningStyle(){
		return this.overallStyle;
	}

	public string GetDescription(){
		return this.description;
	}
}
