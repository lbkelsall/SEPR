using UnityEngine;
using System.Collections;

 public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	private NonPlayerCharacter[] characters;
	private Item[] items; 
	private Scene[] scenes;
	private PlayerCharacter playerCharacter;

	//NPC variable declaration

	public PlayerCharacter getPlayerCharacter(){
		return playerCharacter;
	}
		
	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
		InitGame();
	}

	public void AssignDetective(PlayerCharacter detective){
		playerCharacter = detective;
		Debug.Log (playerCharacter.getCharacterID ());
	}


	void InitGame(){
		//Create Detectives 


		//Create NPC's

	}

	void AssignNPCsToScenes(){

	}

	void AssignItemsToScenes(){

	}
}
