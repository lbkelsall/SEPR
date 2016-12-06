using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterInteraction : MonoBehaviour {

	private NonPlayerCharacter character;

	public void SetCharacter(NonPlayerCharacter character){
		this.character = character;
	}

	void OnMouseDown() {
		InterrogationScript.instance.SetInterrogationCharacter (character);
		InterrogationScript.instance.SetReturnScene (SceneManager.GetActiveScene().name);
		SceneManager.LoadScene ("Interrogation Room");
	}
}
 