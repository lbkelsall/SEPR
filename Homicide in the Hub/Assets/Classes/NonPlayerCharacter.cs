using UnityEngine;
using System.Collections.Generic;

public class NonPlayerCharacter : Character {

	private bool isMurderer = false;
	private VerbalClue verbalClue = null;
	private GameObject prefab;
	private List<string> weaknesses;
	private string[] questioningResponces;
	// Use this for initialization

	public NonPlayerCharacter (string characterID, Sprite sprite, string nickname, GameObject prefab, List<string> weaknesses, string[] questioningResponces) :  base(characterID, sprite, nickname) {
		this.prefab = prefab;
		this.weaknesses = weaknesses;
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
		
	public List<string> GetWeaknesses(){
		return this.weaknesses;
	}

	public string GetResponse(string questioningStyle){

		switch(questioningStyle){
		case ("Forceful"):
			return questioningResponces [0];
		case ("Condescending"):
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
		case ("Kind"):
			return questioningResponces [7];
		case ("Inspiring"):
			return questioningResponces [8];
		default:
			return "";

	}
}
}