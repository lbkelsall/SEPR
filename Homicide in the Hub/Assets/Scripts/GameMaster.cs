using UnityEngine;
using System.Collections.Generic;

 public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	private NonPlayerCharacter[] characters;
	private Item[] items; 
	private Scene[] scenes;
	private PlayerCharacter playerCharacter;

	//NPC Sprites
	public Sprite pirateSprite;
	public Sprite mimesSprite;
	public Sprite millionaireSprite;
	public Sprite cowgirlSprite;
	public Sprite romanSprite;
	public Sprite wizardSprite;

	//NPC variable declaration
	private NonPlayerCharacter pirate;
	private NonPlayerCharacter mimes;
	private NonPlayerCharacter millionaire;
	private NonPlayerCharacter cowgirl;
	private NonPlayerCharacter roman; 
	private NonPlayerCharacter wizard;

	public GameObject piratePref;
	public GameObject mimesPref;
	public GameObject millionarePref;
	public GameObject cowgirlPref;
	public GameObject romanPref;
	public GameObject wizardPref;


	//Scene declaration
	private Scene controlRoom;
	private Scene kitchen;
	private Scene lectureTheatre;
	private Scene lakehouse;
	private Scene islandOfInteraction;
	private Scene roof;
	private Scene atrium;
	private Scene undergroundLab;

	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
	}

	void Start(){

		//Defining NPC's
		pirate = new NonPlayerCharacter("Captain Bluebottle",pirateSprite,"Salty Seadog",piratePref);
		mimes = new NonPlayerCharacter("The Mime Twins",mimesSprite,"Silent but Deadly",mimesPref);
		millionaire = new NonPlayerCharacter("Sir Worchester",millionaireSprite,"Money Bags",millionarePref);
		cowgirl = new NonPlayerCharacter("Jesse Ranger",cowgirlSprite,"The Outlaw",cowgirlPref);
		roman = new NonPlayerCharacter("Celcius Maximus",romanSprite,"The Legionnaire", romanPref);
		wizard = new NonPlayerCharacter("Randolf the Deep Purple",wizardSprite,"Dodgy Dealer",wizardPref);
		characters =  new NonPlayerCharacter[6] {pirate,mimes,millionaire,cowgirl,roman,wizard};

		//Defining Scenes
		controlRoom = new Scene("Control Room");
		kitchen = new Scene("Kitchen");
		lectureTheatre = new Scene("Lecture Theatre");
		lakehouse = new Scene("Lakehouse");
		islandOfInteraction = new Scene("Island Of Interaction");
		roof = new Scene ("Roof");
		atrium = new Scene("Atrium");
		undergroundLab = new Scene("Underground Lab");
		scenes = new Scene[8] {atrium,lectureTheatre,lakehouse,controlRoom,kitchen,islandOfInteraction,roof,undergroundLab}; //Larger scenes with more spawn points should be placed towards the start. 

		//Defining Items


		foreach (Scene scene in scenes) {
			scene.ResetScene ();
		}	

		AssignNPCsToScenes (characters,scenes);
		AssignItemsToScenes (items,scenes);

	}

	void AssignNPCsToScenes(NonPlayerCharacter[] characters, Scene[] scenes){
		int sceneCounter = 0;
		Shuffle (characters);
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
		Shuffle (items);
		foreach (Item item in items) {
			scenes [sceneIndex].AddItemToArray (item);
			sceneIndex++;
			if (sceneIndex > scenes.Length) {				
				sceneIndex = 0;
			}
		}
		Debug.Log (items [0]);
	}

	public void AssignDetective(PlayerCharacter detective){
		playerCharacter = detective;
	}

	public void AssignMurderer(NonPlayerCharacter[] characters) {
		int randIndex = Random.Range (0, characters.Length);
		NonPlayerCharacter murderer = characters [randIndex];
		murderer.SetAsMurderer ();
	}

	public PlayerCharacter GetPlayerCharacter(){
		return playerCharacter;
	}

	private void Shuffle<T>(T[] array){ //Based on Fisher-Yates Shuffle
		int n = array.Length;
		for (int i = 0; i < n; i++) {
			int r = i + (int)(Random.Range(0.0f,1.0f) * (n - i));
			T t = array[r];
			array[r] = array[i];
			array[i] = t;
		}
	}

	public Scene GetScene(string sceneName){
		for (int i = 0; i < scenes.Length; i++) {
			if (scenes [i].GetName () == sceneName) {
				return scenes [i];
			} 
		}
		return null;
	}
}
