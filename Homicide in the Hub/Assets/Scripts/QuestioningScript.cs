using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestioningScript : MonoBehaviour {

	private PlayerCharacter detective; 
	private NonPlayerCharacter character;
	public GameObject detectiveGameObject;
	public GameObject characterGameObject;

	public Text[] detectiveStylesText = new Text[3];

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


}
