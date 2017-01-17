using UnityEngine;
using System.Collections.Generic;

public class NonPlayerCharacter : Character {

	private bool isMurderer = false;
	private VerbalClue verbalClue = null;
	private GameObject prefab;
	private List<string> weaknesses;
	private string[] questioningResponses;
	// Use this for initialization

	public NonPlayerCharacter (string characterID, Sprite sprite, string nickname, GameObject prefab, List<string> weaknesses, string[] questioningResponces) :  base(characterID, sprite, nickname) {
		this.prefab = prefab;
		this.weaknesses = weaknesses;
		this.questioningResponses = questioningResponces;
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
			return questioningResponses [0];
		case ("Condescending"):
			return questioningResponses [1];
		case ("Intimidating"):
			return questioningResponses [2];
		case ("Coaxing"):
			return questioningResponses [3];
		case ("Wisecracking"):
			return questioningResponses [4];
		case ("Rushed"):
			return questioningResponses [5];
		case ("Inquisitive"):
			return questioningResponses [6];
		case ("Kind"):
			return questioningResponses [7];
		case ("Inspiring"):
			return questioningResponses [8];
		default:
			return "...";

	}
}
}