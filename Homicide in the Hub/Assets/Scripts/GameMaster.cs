using UnityEngine;
using System.Collections.Generic;
using System.Linq; //Used for take in pick items


 public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	public Scene[] scenes;
	public Item[] itemClues;
	public NonPlayerCharacter[] characters;
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

	//Item Sprite declratation
	public Sprite cutlassSprite;
	public Sprite poisonSprite;
	public Sprite garroteSprite;
	public Sprite knifeSprite;
	public Sprite laserGunSprite;
	public Sprite leadPipeSprite;
	public Sprite westernPistolSprite;
	public Sprite wizardStaffSprite;
	public Sprite beretSprite;
	public Sprite footprintsSprite;
	public Sprite glovesSprite;
	public Sprite wineSprite;
	public Sprite shatteredGlassSprite;
	public Sprite shrapnelSprite;
	public Sprite smellyDeathSprite;
	public Sprite spellbookSprite;
	public Sprite tripwireSprite;

	//Item Declaration
	private MurderWeapon poison;
	private MurderWeapon garrote;
	private MurderWeapon knife;
	private MurderWeapon laserGun;
	private MurderWeapon leadPipe;
	private MurderWeapon westernPistol;
	private MurderWeapon wizardStaff;
	private Item beret;
	private Item footprints;
	private Item gloves;
	private Item wine;
	private Item shatteredGlass;
	private Item shrapnel;
	private Item smellyDeath;
	private Item spellbook;
	private Item tripwire;
	private MurderWeapon murderWeapon;

	//Item Prefabs
	public GameObject cutlassPrefab;
	public GameObject poisonPrefab;
	public GameObject garrotePrefab;
	public GameObject knifePrefab;
	public GameObject laserGunPrefab;
	public GameObject leadPipePrefab;
	public GameObject westernPistolPrefab;
	public GameObject wizardStaffPrefab;
	public GameObject beretPrefab;
	public GameObject footprintsPrefab;
	public GameObject glovesPrefab;
	public GameObject winePrefab;
	public GameObject shatteredGlassPrefab;
	public GameObject shrapnelPrefab;
	public GameObject smellyDeathPrefab;
	public GameObject spellbookPrefab;
	public GameObject tripwirePrefab;

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

		//Defining Placeholder Verbal Clues
		VerbalClue vc1 = new VerbalClue ("ID1", "D1");
		VerbalClue vc2 = new VerbalClue ("ID2", "D2");
		VerbalClue vc3 = new VerbalClue ("ID3", "D3");
		VerbalClue vc4 = new VerbalClue ("ID4", "D4");
		VerbalClue vc5 = new VerbalClue ("ID5", "D5");
		VerbalClue vc6 = new VerbalClue ("ID6", "D6");
		VerbalClue vc7 = new VerbalClue ("ID7", "D7");

		//Defining NPC's
		pirate = new NonPlayerCharacter("Captain Bluebottle",pirateSprite,"Salty Seadog",piratePref);
		mimes = new NonPlayerCharacter("The Mime Twins",mimesSprite,"Silent but Deadly",mimesPref);
		millionaire = new NonPlayerCharacter("Sir Worchester",millionaireSprite,"Money Bags",millionarePref);
		cowgirl = new NonPlayerCharacter("Jesse Ranger",cowgirlSprite,"The Outlaw",cowgirlPref);
		roman = new NonPlayerCharacter("Celcius Maximus",romanSprite,"The Legionnaire", romanPref);
		wizard = new NonPlayerCharacter("Randolf the Deep Purple",wizardSprite,"Dodgy Dealer",wizardPref);

		//Defining Scenes
		controlRoom = new Scene("Control Room");
		kitchen = new Scene("Kitchen");
		lectureTheatre = new Scene("Lecture Theatre");
		lakehouse = new Scene("Lakehouse");
		islandOfInteraction = new Scene("Island Of Interaction");
		roof = new Scene ("Roof");
		atrium = new Scene("Atrium");
		undergroundLab = new Scene("Underground Lab");

		//Defining Items
		MurderWeapon cutlass = new MurderWeapon(cutlassPrefab,"Cutlass","A worn and well used cutlass",cutlassSprite, "SD");
		poison = new MurderWeapon(poisonPrefab,"Emtpy Poison Bottle","An empty poison bottle ",poisonSprite, "SD");
		garrote = new MurderWeapon(garrotePrefab,"Garrote","Used for strangling a victim to death",garroteSprite, "SD");
		knife = new MurderWeapon(knifePrefab,"Knife","An incredibly sharp tool meant for cutting meat",knifeSprite, "SD");
		laserGun = new MurderWeapon(laserGunPrefab,"Laser Gun","It's still warm which implies it has been recently fired",laserGunSprite, "SD");
		leadPipe = new MurderWeapon(leadPipePrefab,"Lead Pipe","It's a bit battered with a few dents on the side",leadPipeSprite, "SD");
		westernPistol = new MurderWeapon(westernPistolPrefab,"Western Pistol","The gunpowder residue implies it has been recently fired",westernPistolSprite, "SD");
		wizardStaff = new MurderWeapon(wizardStaffPrefab,"Wizard Staff","The gems still seem to be glow as if it has been used recently",wizardStaffSprite, "SD");
		beret = new Item (beretPrefab,"Beret","A hat most stereotypically worn by the French",beretSprite);
		footprints = new Item (footprintsPrefab,"Bloody Footprints","Bloody footprints most likely left by the murderer",footprintsSprite);
		gloves = new Item (glovesPrefab,"Bloddy Gloves","Bloody gloves most likely used by the murderer",glovesSprite);
		wine = new Item (winePrefab,"Fine Wine","An expensive vintage that's close to 100 years old",wineSprite);
		shatteredGlass = new Item (shatteredGlassPrefab,"Shattered Glass","Broken glass shards spread quite close together",shatteredGlassSprite);
		shrapnel = new Item (shrapnelPrefab,"Shrapnel","Shrapnel from an explosion or gun being fired",shrapnelSprite);
		smellyDeath = new Item (smellyDeathPrefab,"Smelly Death","All that remains of the victim",smellyDeathSprite);
		spellbook = new Item (spellbookPrefab,"Spellbook","A spellbook used by those who practise in the magic arts",spellbookSprite);
		tripwire = new Item (tripwirePrefab,"Tripwire","A used tripwire most likely used to immobilize the victim",tripwireSprite);

		MurderWeapon[] murderWeapons = new MurderWeapon[8] {cutlass,poison,garrote,knife,laserGun,leadPipe,westernPistol,wizardStaff};
		Item[] itemClues = new Item [9] {beret,footprints,gloves,wine,shatteredGlass,shrapnel,smellyDeath,spellbook,tripwire};
		NonPlayerCharacter[] characters =  new NonPlayerCharacter[6] {pirate,mimes,millionaire,cowgirl,roman,wizard};
		Scene[] scenes = new Scene[8] {atrium,lectureTheatre,lakehouse,controlRoom,kitchen,islandOfInteraction,roof,undergroundLab};
		VerbalClue[] verbalClues = new VerbalClue[7] { vc1, vc2, vc3, vc4, vc5, vc6, vc7 };

		Scenario scenario = new Scenario (murderWeapons, itemClues, verbalClues, characters);

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