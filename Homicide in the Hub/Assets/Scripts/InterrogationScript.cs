using UnityEngine;
using System.Collections;

public class InterrogationScript : MonoBehaviour {

	private string previousScene;
	private NonPlayerCharacter character;
	private Vector2 playerPosition; 

	public static InterrogationScript instance = null;
	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
	}
		
	public void SetInterrogationCharacter(NonPlayerCharacter character){
		this.character = character;
	}

	public NonPlayerCharacter GetInterrogationCharacter(){
		return this.character;
	}

	public void SetReturnScene(string sceneName){
		this.previousScene = sceneName;
	}

	public string GetReturnScene(){
		return this.previousScene;
	}
		
}
