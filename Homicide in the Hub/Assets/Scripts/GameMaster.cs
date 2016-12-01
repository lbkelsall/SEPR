using UnityEngine;
using System.Collections.Generic;

 public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	private NonPlayerCharacter[] characters;
	private Item[] items; 
	private Scene[] scenes;
	private PlayerCharacter playerCharacter;

	//MPC Sprites
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
		pirate = new NonPlayerCharacter("Captain Bluebottle",pirateSprite,"Salty Seadog");
		mimes = new NonPlayerCharacter("The Mime Twins",mimesSprite,"Silent but Deadly");
		millionaire = new NonPlayerCharacter("Sir Worchester",millionaireSprite,"Money Bags");
		cowgirl = new NonPlayerCharacter("Jesse Ranger",cowgirlSprite,"The Outlaw");
		roman = new NonPlayerCharacter("Celcius Maximus",romanSprite,"The Legionnaire");
		wizard = new NonPlayerCharacter("Randolf the Light Blue",wizardSprite,"Dodgy Dealer");
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
		scenes = new Scene[8] {controlRoom,kitchen,lectureTheatre,lakehouse,islandOfInteraction,roof,atrium,undergroundLab};

	}

	void AssignNPCsToScenes(NonPlayerCharacter[] characters, Scene[] scenes){
		int sceneCounter = 0;
		Shuffle (characters);

		foreach (NonPlayerCharacter character in characters){
			scenes [sceneCounter].AddToArray (character);
			sceneCounter += 1;
		}

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

	public void AssignDetective(PlayerCharacter detective){
		playerCharacter = detective;
		Debug.Log (playerCharacter.getCharacterID ());
		AssignNPCsToScenes (characters,scenes);
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
