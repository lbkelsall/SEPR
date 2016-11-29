using UnityEngine;
using System.Collections.Generic;

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

	//Puts a randomly chosen item in each scene (assumes there's one item for each scene).
	void AssignItemsToScenes(Item[] itemsArray, Scene[] sceneArray){

		Dictionary<Scene, Item> itemsInSceneDict = new Dictionary<Scene, Item> ();
		foreach (Scene sceneObject in sceneArray) {

			int randomItemIndex = Random.Range (0, itemsArray.Length);
			Item randomItem = itemsArray [randomItemIndex];

			itemsInSceneDict.Add (sceneObject, randomItem);

			Item[] newItemsArray = new Item[itemsArray.Length -1];
			int index = 0;
			foreach (Item itemObject in itemsArray) {
				if (itemObject != randomItem) {
					newItemsArray [index] = itemObject;
					index++;
				}
			}
			itemsArray = newItemsArray;
		}
	}
}
