using UnityEngine;
using System.Collections.Generic;
using System.Linq; //Used for take in pick items


 public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	static public Scene[] scenes;
	public Item[] itemClues;
	public VerbalClue[] verbalClues;
	public NonPlayerCharacter[] characters;
	public List<Clue> relevantClues;
	private MurderWeapon[] murderWeapons;
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

	private NonPlayerCharacter murderer;

	//Other
	private List<Item> relevant_items;
	private List<VerbalClue> relevant_verbal_clues;
	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
	}

	void Start(){

		//Responce Arrays
		string[] pirateResponses = new string[9] {
			"Shiver me timbers I know nothing!",
			"Arrr matey it ain’t that difficult to understand.",
			"Shiver me timbers, how dare ye threaten me!",
			"Arrr, no matey I really don’t think I do. I saw nothing!",
			"Ho ho ho, Arr matey I didn’t see anything!",
			"Shiver me timbers ye need to plan ye lunch breaks better!",
			"Arrr matey I saw nothing of import.",
			"Arr, matey I suppose ye do, but I saw nothing.",
			"Arrr matey I don’t think ye need my help to solve this conundrum."
		};

		string[] mimeResponses = new string[9] {
			"The mimes are taken aback, but contribute nothing more.",
			"The mimes shake their heads.",
			"The mimes flinch, but tell you nothing.",
			"The mimes shake their heads.",
			"The mimes imitate laughter but tell you nothing.",
			"The mimes look at their wrist watches with a puzzled expression.",
			"The mines mime out some routine which doesn’t make sense and contribute nothing.",
			"The mimes look at you with passing curiosity but contribute nothing more.",
			"The mimes shake their heads. They tell you nothing."
		};

		string[] millionaireResponses = new string[9] {
			"Don’t try and force me to tell you anything. I’ve got more money than you.",
			"Don’t patronise me you cretin. I’ve got more money than you.",
			"How dare you threaten me you lunatic, I’ve got more money than you.",
			"No my dear fellow for you see I have more money than you.",
			"Ha ha ha. Not that funny dear fellow, you’ll need more money to make it funnier.",
			"My good man, I know that time is money, but you can’t rush magnificence!",
			"My good man, there isn’t enough money around here to warrant seeing anything.",
			"I thank you for your kindness, but it would be better with some patronage!",
			"My good man, you don’t need my help to solve this. Not to mention there’s no money involved."
		};

		string[] cowgirlResponses = new string[9] {
			"I appreciate your candour pardner but I didn’t see anything.",
			"Pardner I do understand, I just didn’t see anything.",
			"Pardner I don’t appreciate threats so don’t try it.",
			"Pardner I didn’t see anything, I wasn’t paying attention.",
			"Ha ha ha, funny pardner but I still didn’t see anything.",
			"I don’t know nuthin'. If you’ve got to be gone by high noon, I’d go ask someone else.",
			"I understand pardner but I didn’t see anything",
			"Thank you pardner, but I didn’t see anything. ",
			"Pardner, you’ll have to solve this one without my help, I didn’t see anything."
		};

		string[] romanResponses = new string[9] {
			"What Ho! I understand you want to solve the problem but I saw nothing!",
			"What Ho! Yes I understand, but I saw nothing!",
			"What Ho! Don’t try and threaten me you madman!",
			"What Ho! I didn’t see anything.",
			"What Ho ho ho ho! That’s funny but I saw nothing of interest.",
			"What Ho! I feel you’re trying to rush an answer out of me! Nay I say, Nay!",
			"What Ho! My good man you are inquisitive but I don’t know anything.",
			"What Ho! Thanks my good man but I didn’t see anything.",
			"What Ho!  My good man I’m sorry but I saw nothing."
		};

		string[] wizardResponses = new string[9] {
			"Errrm...are you sure I can’t interest you in some merchandise instead?",
			"Errrm...I do understand what is going on, I just didn’t see anything.",
			"Errrm...I think you might need to calm down, I’ve got something for that.",
			"Errrm...I saw nothing but I have seen some of my merchandise, would you like some?",
			"Hee hee hee...that's funny. Errrm...but I still saw nothing though.",
			"*Looks around shiftily* Sorry mate, I don’t know anything.",
			"Errrm...I understand, but wouldn’t you prefer to buy some merchandise instead?",
			"Errrm...yes there was something…. But I’ve forgotten it now.",
			"Errrm...are you sure? I’m not that useful really."
		};

		//Weaknesses
		List<string> pirateWeaknesses = new List<string> {"Forceful","Wisecracking","Kind"};
		List<string> mimeWeaknesses = new List<string> {"Intimidating","Coaxing","Inspiring"};
		List<string> millionaireWeaknesses = new List<string> {"Forceful","Rushed","Kind"};
		List<string> cowgirlWeaknesses = new List<string> {"Condescending","Wisecracking","Inspiring"};
		List<string> romanWeaknesses = new List<string> {"Condescending","Coaxing","Inquisitive"};
		List<string> wizardWeaknesses = new List<string> {"Intimidating","Rushed","Inquisitive"};


		//Defining NPC's
		pirate = new NonPlayerCharacter("Captain Bluebottle",pirateSprite,"Salty Seadog",piratePref,pirateWeaknesses ,pirateResponses);
		mimes = new NonPlayerCharacter("The Mime Twins",mimesSprite,"Silent but Deadly",mimesPref,mimeWeaknesses, mimeResponses );
		millionaire = new NonPlayerCharacter("Sir Worchester",millionaireSprite,"Money Bags",millionarePref,millionaireWeaknesses, millionaireResponses );
		cowgirl = new NonPlayerCharacter("Jesse Ranger",cowgirlSprite,"The Outlaw",cowgirlPref,cowgirlWeaknesses, cowgirlResponses );
		roman = new NonPlayerCharacter("Celcius Maximus",romanSprite,"The Legionnaire", romanPref,romanWeaknesses, romanResponses );
		wizard = new NonPlayerCharacter("Randolf the Deep Purple",wizardSprite,"Dodgy Dealer",wizardPref,wizardWeaknesses, wizardResponses );

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

		murderWeapons = new MurderWeapon[8] {cutlass,poison,garrote,knife,laserGun,leadPipe,westernPistol,wizardStaff};
		itemClues = new Item [9] {beret,footprints,gloves,wine,shatteredGlass,shrapnel,smellyDeath,spellbook,tripwire};
		characters =  new NonPlayerCharacter[6] {pirate,mimes,millionaire,cowgirl,roman,wizard};
		scenes = new Scene[8] {atrium,lectureTheatre,lakehouse,controlRoom,kitchen,islandOfInteraction,roof,undergroundLab};
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
		Scenario scenario = new Scenario (murderWeapons, itemClues, characters);

		string motive = scenario.chooseMotive ();
		murderer = scenario.chooseMurderer ();

		scenario.chooseWeapon ();
		MurderWeapon weapon = scenario.getWeapon ();
		scenario.CreateVerbalClues (); 
		scenario.BuildCluePools (motive, murderer, weapon);
		scenario.DistributeVerbalClues ();

		itemClues = scenario.getItemCluePool ().ToArray ();
		characters = scenario.getNPCs ();
		verbalClues = scenario.getVerbalCluePool ().ToArray ();
		relevant_items = scenario.getRelevantItems ();
		relevant_verbal_clues = scenario.getRelevantVerbalClues ();
		relevantClues = scenario.getRelevantClues (); 
		NotebookManager.instance.logbook.Reset();	//Reset logbook
		NotebookManager.instance.inventory.Reset();	//Reset inventory
		NotebookManager.instance.UpdateNotebook();

		Debug.Log (murderer.getCharacterID ());
		foreach (Item item in relevant_items){
			Debug.Log (item.getID ());
		}

		foreach (VerbalClue clue in relevant_verbal_clues){
			Debug.Log (clue.getID ());
		}


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
		
	public List<Item> GetRelevantItems(){
		return this.relevant_items;
	}

	public List<VerbalClue> GetRelevantVerbalClues(){
		return this.relevant_verbal_clues;
	}

	public string GetMurderer(){
		return this.murderer.getCharacterID();
	}
}