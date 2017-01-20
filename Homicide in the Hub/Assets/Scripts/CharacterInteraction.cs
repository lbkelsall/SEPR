using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterInteraction : MonoBehaviour {
	//Used on the NonPlayerCharacter prefabs 

	//Which character it is
	private NonPlayerCharacter character;

	//Sets the character
	public void SetCharacter(NonPlayerCharacter character){
		this.character = character;
	}

	//When the character is clicked on
	void OnMouseDown() {
		//Pass the character and current scene to the interrogation script to be used in the interrogation room
		InterrogationScript.instance.SetInterrogationCharacter (character);
		InterrogationScript.instance.SetReturnScene (SceneManager.GetActiveScene().name);
		SceneManager.LoadScene ("Interrogation Room");
	}
}
 