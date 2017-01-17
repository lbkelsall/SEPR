using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestioningScript : MonoBehaviour {

	private PlayerCharacter detective; 
	private NonPlayerCharacter character;
	public GameObject detectiveGameObject;
	public GameObject characterGameObject;

	public Text[] detectiveStylesText = new Text[3]; //Where Left-most button is 1 and rightmost is 3
	public Text clueSpeech;

	// Use this for initialization
	void Start () {
		//Get detective and character from singletons
		detective = GameMaster.instance.GetPlayerCharacter(); 
		character = InterrogationScript.instance.GetInterrogationCharacter ();

		//Change sprites to correct characters
		SpriteRenderer detectiveSR = detectiveGameObject.GetComponent<SpriteRenderer> ();
		detectiveSR.sprite = detective.getSprite ();

		SpriteRenderer characterSR = characterGameObject.GetComponent<SpriteRenderer> ();
		characterSR.sprite = character.getSprite ();

		//Set Text in Style buttons to Styles of chosen detective
		for (int i = 0; i<3; i++){	
			detectiveStylesText [i].text = detective.GetQuestioningStyles () [i];
		}
			
	}

	public void QuestionCharacter(int reference){
		string choice; 
		List<string> weaknesses;
		choice = GetQuestioningChoice(reference);
		weaknesses = character.GetWeaknesses ();
		string response;
		if ((weaknesses.Contains(choice)) && (character.getVerbalClue() != null)) {
			VerbalClue clue = character.getVerbalClue ();
			if (!NotebookManager.instance.logbook.GetLogbook ().Contains (character.getVerbalClue ())) {
				response = "Clue Added: " + clue.getDescription (); 
				NotebookManager.instance.logbook.AddVerbalClueToLogbook (clue);
				NotebookManager.instance.UpdateNotebook ();
			} else {
				response = "Clue Already Obtained";
			}
		} else {
			response = character.GetResponse (choice);
		}

		clueSpeech.text = response; 
	}




	private string GetQuestioningChoice(int reference){
		string choice = detective.GetQuestioningStyles () [reference];
		return choice;
	}

}
