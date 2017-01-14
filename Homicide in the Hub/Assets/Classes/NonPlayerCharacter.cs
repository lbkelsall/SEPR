using UnityEngine;
using System.Collections;

public class NonPlayerCharacter : Character {

	private bool isMurderer = false;
	private VerbalClue verbalClue = null;
	private GameObject prefab;
	private string weakness;
	private string[] questioningResponces;
	// Use this for initialization

	public NonPlayerCharacter (string characterID, Sprite sprite, string nickname, GameObject prefab, string weakness, string[] questioningResponces) :  base(characterID, sprite, nickname) {
		this.prefab = prefab;
		this.weakness = weakness;
		this.questioningResponces = questioningResponces; 
	}

	public bool IsMurderer(){
		return this.isMurderer;
	}

	public void SetAsMurderer(){
		this.isMurderer = true;
	}

	public void setVerbalClue (VerbalClue clue) {
		verbalClue = clue;
	}

	public VerbalClue getVerbalClue () {
		return verbalClue;
	}

	public GameObject GetPrefab(){
		return this.prefab;
	}
		
	public string GetWeakness(){
		return this.weakness;
	}

	public string GetResponce(string questioningStyle){

		switch(questioningStyle){
		case ("Forceful"):
			return questioningResponces [0];
		case ("Condesending"):
			return questioningResponces [1];
		case ("Intimidating"):
			return questioningResponces [2];
		case ("Coaxing"):
			return questioningResponces [3];
		case ("Wisecracking"):
			return questioningResponces [4];
		case ("Rushed"):
			return questioningResponces [5];
		case ("Inquisitive"):
			return questioningResponces [6];
		case ("Polite"):
			return questioningResponces [7];
		case ("Inspiring"):
			return questioningResponces [8];
			

	}
}
