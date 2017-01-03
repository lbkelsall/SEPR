using UnityEngine;
using System.Collections.Generic;
using System.Linq; //Used for take in pick items


 public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	public static Scene[] scenes;
	public Item[] itemClues;
	public VerbalClue[] verbalClues;
	public NonPlayerCharacter[] characters;
	private PlayerCharacter playerCharacter;

	//Scene declaration
	private Scene controlRoom;
	private Scene kitchen;
	private Scene lectureTheatre;
	private Scene lakehouse;
	private Scene islandOfInteraction;
	private Scene roof;
	private Scene atrium;
	private Scene undergroundLab;

	//Other

	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
	}

	void Start(){

		//Defining Scenes
		controlRoom = new Scene("Control Room");
		kitchen = new Scene("Kitchen");
		lectureTheatre = new Scene("Lecture Theatre");
		lakehouse = new Scene("Lakehouse");
		islandOfInteraction = new Scene("Island Of Interaction");
		roof = new Scene ("Roof");
		atrium = new Scene("Atrium");
		undergroundLab = new Scene("Underground Lab");

		scenes = new Scene[8] {atrium,lectureTheatre,lakehouse,controlRoom,kitchen,islandOfInteraction,roof,undergroundLab};

		Scenario scenario = new Scenario ();

		scenario.init ();
		string motive = scenario.chooseMotive ();
		NonPlayerCharacter murderer = scenario.chooseMurderer ();
		scenario.chooseWeapon ();
		MurderWeapon weapon = scenario.getWeapon ();
		scenario.BuildCluePools (motive, murderer, weapon);
		scenario.DistributeVerbalClues ();

		itemClues = scenario.getItemCluePool ().ToArray ();
		characters = scenario.getNPCs ();
		verbalClues = scenario.getVerbalCluePool ().ToArray ();

	}

	void AssignNPCsToScenes(NonPlayerCharacter[] characters, Scene[] scenes){
		int sceneCounter = 0;
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (characters);
		foreach (NonPlayerCharacter character in characters){ 	//For every character in the randomly shuffled array
			scenes [sceneCounter].AddNPCToArray (character);		//Assign a character to a scene
			sceneCounter += 1;									//Increment sceneCounter
			if (sceneCounter > scenes.Length) {					//If the counter is above the number of scenes cycle to the first scene.  
				sceneCounter = 0;
			}
		}

	}

	void AssignItemsToScenes(Item[] items, Scene[] scenes) {
		int sceneIndex = 0;
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (items);
		foreach (Item item in items) {
			scenes [sceneIndex].AddItemToArray (item);
			sceneIndex++;
			if (sceneIndex > scenes.Length) {				
				sceneIndex = 0;
			}
		}
	}

	public void CreateNewGame(PlayerCharacter detective){ //Called when the player presses play
		NotebookManager.instance.logbook.Reset();	//Reset logbook
		NotebookManager.instance.inventory.Reset();	//Reset inventory
		ResetAll(scenes);
		AssignNPCsToScenes (characters,scenes);				//Assigns NPCS to scenes
		AssignItemsToScenes (itemClues,scenes);					//Assigns Items to scenes
		playerCharacter = detective;	
	}	
		

	public PlayerCharacter GetPlayerCharacter(){
		return playerCharacter;
	}

	public Scene GetScene(string sceneName){
		for (int i = 0; i < scenes.Length; i++) {
			if (scenes [i].GetName () == sceneName) {
				return scenes [i];
			} 
		}
		return null;
	}

	public void ResetAll(Scene[] scenes){
		foreach (Scene scene in scenes) {
			scene.ResetScene ();
		}

	}
		
}