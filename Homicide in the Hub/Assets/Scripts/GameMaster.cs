using UnityEngine;
using System.Collections.Generic;
using System.Linq; //Used for take in pick items

 public class GameMaster : MonoBehaviour {
	/* Initialises all of the objects required generate the mystery and the game world except the detectives and verbal clues. 
	 * Distibutes the clues and characters throughout the scenes.
	*/
	public Scenario scenario; 

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
	//Made public to allow for dragging and dropping of Sprites
	public Sprite pirateSprite;
	public Sprite mimesSprite;
	public Sprite millionaireSprite;
	public Sprite cowgirlSprite;
	public Sprite romanSprite;
	public Sprite wizardSprite;
	public Sprite chubbieSprite;	//ADDITION BY WEDUNNIT
	public Sprite reginaldSprite;	//ADDITION BY WEDUNNIT
	public Sprite hemanSprite;	//ADDITION BY WEDUNNIT
	public Sprite scientistSprite;	//ADDITION BY WEDUNNIT

	//NPC Prefabs
	//Made public to allow for dragging and dropping of prefabs
	public GameObject piratePref;
	public GameObject mimesPref;
	public GameObject millionarePref;
	public GameObject cowgirlPref;
	public GameObject romanPref;
	public GameObject wizardPref;
	public GameObject chubbiePref;	//ADDITION BY WEDUNNIT
	public GameObject hemanPref;	//ADDITION BY WEDUNNIT
	public GameObject scientistPref;	//ADDITION BY WEDUNNIT
	public GameObject reginaldPref;	//ADDITION BY WEDUNNIT


	//Item Sprite decleratation
	//Made public to allow for dragging and dropping of sprites
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
	public Sprite whistleSprite;	//ADDITION BY WEDUNNIT
	public Sprite toastSprite;		//ADDITION BY WEDUNNIT
	public Sprite staplerSprite;	//ADDITION BY WEDUNNIT
	public Sprite seaweedSprite;	//ADDITION BY WEDUNNIT
	public Sprite sandwitchSprite;	//ADDITION BY WEDUNNIT
	public Sprite purseSprite;		//ADDITION BY WEDUNNIT
	public Sprite plungerSprite;	//ADDITION BY WEDUNNIT
	public Sprite monocleSprite;	//ADDITION BY WEDUNNIT
	public Sprite featherSprite;	//ADDITION BY WEDUNNIT
	public Sprite chefHatSprite;	//ADDITION BY WEDUNNIT


	//Item Prefabs 
	//Made public to allow for dragging and dropping of prefabs
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
	public GameObject whistlePrefab;        //ADDITION BY WEDUNNIT
	public GameObject toastPrefab;        	//ADDITION BY WEDUNNIT
	public GameObject staplerPrefab;        //ADDITION BY WEDUNNIT
	public GameObject seaweedPrefab;        //ADDITION BY WEDUNNIT
	public GameObject sandwitchPrefab;      //ADDITION BY WEDUNNIT
	public GameObject pursePrefab;        	//ADDITION BY WEDUNNIT
	public GameObject plungerPrefab;        //ADDITION BY WEDUNNIT
	public GameObject monoclePrefab;        //ADDITION BY WEDUNNIT
	public GameObject featherPrefab;        //ADDITION BY WEDUNNIT
	public GameObject chefHatPrefab;        //ADDITION BY WEDUNNIT

	private NonPlayerCharacter murderer;

	//Relevant Clues
	private List<Item> relevant_items;
	private List<VerbalClue> relevant_verbal_clues;

	private float gameScore;	//ADDITION BY WEDUNNIT

	//Sets as a Singleton
	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
	}
		
	void Update(){		//ADDITION BY WEDUNNIT
		if (gameScore > 0) {
			gameScore -= Time.deltaTime;
		} else {
			gameScore = 0;
		}
	}

	void Start(){
		//Initialises Variables
		//Responce Arrays
		string[] pirateResponses = new string[10] {		//UPDATED BY WEDUNNIT
			"Shiver me timbers I know nothing!",
			"Arrr matey it ain’t that difficult to understand.",
			"Shiver me timbers, how dare ye threaten me!",
			"Arrr, no matey I really don’t think I do. I saw nothing!",
			"Ho ho ho, Arr matey I didn’t see anything!",
			"Shiver me timbers ye need to plan ye lunch breaks better!",
			"Arrr matey I saw nothing of import.",
			"Aye cap'n I suppose ye do, but I saw nothing.",
			"Arrr matey I don’t think ye need my help to solve this conundrum.",
			"Arr me hearty, ye won't get nought from me until you find more clues ye whipper snapper!"//ADDITION BY WEDUNNIT
		};

		string[] mimeResponses = new string[10] {		//UPDATED BY WEDUNNIT
			"The mimes are taken aback, but contribute nothing more.",
			"The mimes shake their heads.",
			"The mimes flinch, but tell you nothing.",
			"The mimes shake their heads.",
			"The mimes imitate laughter but tell you nothing.",
			"The mimes look at their wrist watches with a puzzled expression.",
			"The mines mime out some routine which doesn’t make sense and contribute nothing.",
			"The mimes look at you with passing curiosity but contribute nothing more.",
			"The mimes shake their heads. They tell you nothing.",
			"The mimes stare at you in a way that suggest you need more information before you can accuse them again"//ADDITION BY WEDUNNIT
		};

		string[] millionaireResponses = new string[10] {		//UPDATED BY WEDUNNIT
			"Don’t try and force me to tell you anything. I’ve got more money than you will ever have.",
			"Don’t patronise me you cretin. I’ve got more money than you.",
			"How dare you threaten me you lunatic, I’ve got more money than you.",
			"No my dear fellow for you see I have more money than you.",
			"Ha ha ha. Not that funny dear fellow, you’ll need more money to make it funnier.",
			"My good man, I know that time is money, but you can’t rush magnificence!",
			"My good man, there isn’t enough money around here to warrant seeing anything.",
			"I thank you for your kindness, but it would be better with some patronage!",
			"My good man, you don’t need my help to solve this. Not to mention there’s no money involved.",
			"I don't need to talk to you. I have enough means to live my own life. If you find anything new I'd be happy to help, but I refuse to help you any further."//ADDITION BY WEDUNNIT
		};

		string[] cowgirlResponses = new string[10] {		//UPDATED BY WEDUNNIT
			"I appreciate your candour partner but I didn’t see anything.",
			"Partner, I do understand, I just didn’t see anything.",
			"I don’t appreciate threats, you yellow-bellied cowpoke, so don’t try it.",
			"Partner I didn’t see anything, I wasn’t paying attention.",
			"Ha ha ha, funny partner but I still didn’t see anything.",
			"I don’t know nuthin'. If you’ve got to be gone by high noon, I’d go ask someone else.",
			"I understand partner but I didn’t see anything",
			"Thank you partner, but I didn’t see anything. ",
			"Howdy, you’ll have to solve this one without my help, I didn’t see anything.",
			"If you’re not careful I’ll challange you to a draw. If you dig up any new evidence, ask me about it, otherwise I’m not interested in talking to you."	//ADDITION BY WEDUNNIT

		};

		string[] romanResponses = new string[10] {		//UPDATED BY WEDUNNIT
			"What Ho! I understand you want to solve the problem but I know nothing I havent already told the emperor!",
			"What Ho! Yes I understand, but I saw nothing!",
			"What Ho! Don’t try and threaten me you madman! I'm an expert with the blade.",
			"What Ho! I didn’t see anything.",
			"What Ho ho ho! That’s funny but I saw nothing of interest.",
			"What Ho! I feel you’re trying to rush an answer out of me! Nay I say, Nay!",
			"What Ho! My good man you are inquisitive but I don’t know anything.",
			"What Ho! Thanks my good man but I didn’t see anything.",
			"What Ho! My good man I’m sorry but I saw nothing.",
			"I have received command to ignore your questioning good sir. Unless you find anything new to ask me about..."//ADDITION BY WEDUNNIT
		};

		string[] wizardResponses = new string[10] {		//UPDATED BY WEDUNNIT
			"Errrm...are you sure I can’t interest you in some 'merchandise' instead?",
			"Errrm...I do understand what is going on, I just didn’t see anything. Would you like to by any Triple Sod?",
			"Errrm...I think you might need to calm down, I’ve got something for that.",
			"Errrm...I saw nothing but I have seen some of my merchandise, would you like some?",
			"Hee hee hee...that's funny. ...but I still saw nothing probably because I'm tripping. See me late if you want anything!",
			"*Looks around shiftily* Sorry mate, I don’t know anything.",
			"Errrm...I understand, but wouldn’t you prefer to buy some merchandise instead?",
			"Errrm...yes there was something…. But I’ve forgotten it now. Probaby all these Yellow Bentines I've been taking. Can I offer you any?",
			"Errrm...are you sure? I’m not that useful really. ...Unless you have a craving for some Clarky Cat? I have plenty of that.",
			"Child, unfortunately I cannot answer any more questions like that when you're accusing me of murder willy-nilly. If you have any new evidence, please let me know and I'll se what I can do."//ADDITION BY WEDUNNIT
		};

		string[] chubbieResponses = new string[10] {	//ADDITION BY WEDUNNIT
			"The telechubbie covers its eyes. It looks... sad?",
			"The telechubbie shakes its head. You don't think it knows anything.",
			"The telechubbie covers its eyes. It looks... scared?",
			"The telechubbie tilts its head in confusion.",
			"The telechubbie laughs, but it doesn't seem to know about anything.",
			"The telechubbie looks around, confused.",
			"The telechubbie looks interested, but doesn't seem to know anything useful.",
			"The telechubbie offers you a hug. You refuse.",
			"The telechubbie looks happy, but doesn't reveal anything.",
			"The telechubbie smiles joyfully, but keeps its mouth closed. Maybe if you found some more information it would be more willing to help."
		};

		string[] hemanResponses = new string[10] {	//ADDITION BY WEDUNNIT
			"By the power of Greyskull, I cannot help you.",
			"By the power of Greyskull, can you... not?",
			"By the power of Greyskull, I will not be intimidated!",
			"By the power of Greyskull, I will not fall for your deception!",
			"By the power of Greyskull, that was a good joke!",
			"By the power of Greyskull, I think you need to slow down.",
			"By the power of Greyskull, I know nothing!",
			"By the power of Greyskull, I'm afraid that I don't feel the same.",
			"By the power of Greyskull, I am inspired but I cannot help you.",
			"Greyskull does not support your actions. Find more clues, and by the power of Greyskull you will find the blasted murderer!"
		};

		string[] scientistResponses = new string[10] {	//ADDITION BY WEDUNNIT
			//TODO: REDO ALL
			"You fool! I know nothing of the sort!",
			"Don't look down on me young man, you know nothing!",
			"Don't try to intimidate me, my knowledge far surpasses yours!",
			"While I would like to help you, what you seek far surpasses my knowledge.",
			"Not only can I not help you, but your jokes are unsophisticated and dull!",
			"Don't rush me, young man! You can't rush science!",
			"Your thirst for knowledge is appreciated, however I am in no position to aid you.",
			"You fool! Science has no room for your pathetic 'emotions'!",
			"...May I inquire as to what the point of that was?",
			"May I suggest following the scientific method? That is to say, collect more evidence to support your hypothesis."	
		};

		string[] reginaldResponses = new string[10] {	//ADDITION BY WEDUNNIT
			"Quack! (Good sir, I will inform you that I have no information to provide to you!)",
			"Quack! (Good sir, I will inform you that I will not be talked to in this manner!)",
			"Quack! (Good sir, I will inform you that I will not tolerate such brash behaviour!)",
			"Quack! (Good sir, I will inform you that I cannot help you in this matter!)",
			"Quack! (Good sir, I will inform you that now is not the time for such tomfoolery!)",
			"Quack! (Good sir, I will inform you that such haste is excessive and detrimental!)",
			"Quack! (Good sir, I will inform you that you are wasting your time with this questioning!)", 	//ADDITION BY WEDUNNIT
			"Quack! (Good sir, I will inform you that I am a married goose and your approaches are unwarranted!)",
			"Quack! (Good sir, I will inform you that I cannot aide you in your investigation!)",
			"QUACK! (Dear sir, ask me about anything new you find, but I do not appreciate your reckless accusations."
		};

		//Weaknesses
		List<string> pirateWeaknesses = new List<string> {"Forceful","Wisecracking","Kind"};
		List<string> mimeWeaknesses = new List<string> {"Intimidating","Coaxing","Inspiring"};
		List<string> millionaireWeaknesses = new List<string> {"Forceful","Rushed","Kind"};
		List<string> cowgirlWeaknesses = new List<string> {"Condescending","Wisecracking","Inspiring"};
		List<string> romanWeaknesses = new List<string> {"Condescending","Coaxing","Inquisitive"};
		List<string> wizardWeaknesses = new List<string> {"Intimidating","Rushed","Inquisitive"};
		List<string> chubbieWeaknesses = new List<string> {"Condescending", "Wizecracking", "Kind"};	//ADDITION BY WEDUNNIT
		List<string> scientistWeaknesses = new List<string> {"Forceful", "Coaxing", "Inspiring"};		//ADDITION BY WEDUNNIT
		List<string> hemanWeaknesses = new List<string> {"Condescending","Rushed","Kind"};				//ADDITION BY WEDUNNIT
		List<string> reginaldWeaknesses = new List<string> {"Forceful", "Coaxing","Inspiring"};			//ADDITION BY WEDUNNIT


		//Defining NPC's
		NonPlayerCharacter pirate = new NonPlayerCharacter("Captain Bluebottle",pirateSprite,"Salty Seadog",piratePref,pirateWeaknesses ,pirateResponses);
		NonPlayerCharacter mimes = new NonPlayerCharacter("The Mime Twins",mimesSprite,"mimes",mimesPref,mimeWeaknesses, mimeResponses );
		NonPlayerCharacter millionaire = new NonPlayerCharacter("Sir Worchester",millionaireSprite,"Money Bags",millionarePref,millionaireWeaknesses, millionaireResponses );
		NonPlayerCharacter cowgirl = new NonPlayerCharacter("Jesse Ranger",cowgirlSprite,"Outlaw",cowgirlPref,cowgirlWeaknesses, cowgirlResponses );
		NonPlayerCharacter roman = new NonPlayerCharacter("Celcius Maximus",romanSprite,"Legionnaire", romanPref,romanWeaknesses, romanResponses );
		NonPlayerCharacter wizard = new NonPlayerCharacter("Randolf the Deep Purple",wizardSprite,"Dodgy Dealer",wizardPref,wizardWeaknesses, wizardResponses );
		NonPlayerCharacter chubbie = new NonPlayerCharacter("Tinky Wobbly",chubbieSprite,"Telechubbie",chubbiePref,chubbieWeaknesses, chubbieResponses );					//ADDITION BY WEDUNNIT
		NonPlayerCharacter heman = new NonPlayerCharacter("HisMan",hemanSprite,"Superhero",hemanPref,hemanWeaknesses, hemanResponses );										//ADDITION BY WEDUNNIT
		NonPlayerCharacter scientist = new NonPlayerCharacter("Dr Emmanuel Brown",scientistSprite,"Mad scientist",scientistPref,scientistWeaknesses, scientistResponses );	//ADDITION BY WEDUNNIT
		NonPlayerCharacter reginald = new NonPlayerCharacter("Reginald Montgomery IV",reginaldSprite,"Reginald M IV",reginaldPref,reginaldWeaknesses, reginaldResponses );	//ADDITION BY WEDUNNIT


		//Defining Scenes
		Scene controlRoom = new Scene("Control Room");
		Scene kitchen = new Scene("Kitchen");
		Scene lectureTheatre = new Scene("Lecture Theatre");
		Scene lakehouse = new Scene("Lakehouse");
		Scene islandOfInteraction = new Scene("Island of Interaction");
		Scene roof = new Scene ("Roof");
		Scene atrium = new Scene("Atrium");
		Scene undergroundLab = new Scene("Underground Lab");

		//Defining Items
		MurderWeapon cutlass = new MurderWeapon(cutlassPrefab,"Cutlass","A worn and well used cutlass",cutlassSprite, "SD");
		MurderWeapon poison = new MurderWeapon(poisonPrefab,"Empty Poison Bottle","This had poison in once ",poisonSprite, "SD");
		MurderWeapon garrote = new MurderWeapon(garrotePrefab,"Garrote","Used for strangling someone... to death!",garroteSprite, "SD");
		MurderWeapon knife = new MurderWeapon(knifePrefab,"Knife","A sharp tool meant for cutting meat",knifeSprite, "SD");
		MurderWeapon laserGun = new MurderWeapon(laserGunPrefab,"Laser Gun","It's still warm, implying it has been recently fired",laserGunSprite, "SD");
		MurderWeapon leadPipe = new MurderWeapon(leadPipePrefab,"Lead Pipe","It's a bit battered with a few dents on the side",leadPipeSprite, "SD");
		MurderWeapon westernPistol = new MurderWeapon(westernPistolPrefab,"Western Pistol","The gunpowder residue implies it has been recently fired",westernPistolSprite, "SD");
		MurderWeapon wizardStaff = new MurderWeapon(wizardStaffPrefab,"Wizard Staff","The gems still seem to be glow as if it has been used recently",wizardStaffSprite, "SD");
		Item beret = new Item (beretPrefab,"Beret","A hat most stereotypically worn by the French",beretSprite);
		Item footprints = new Item (footprintsPrefab,"Bloody Footprints","Bloody footprints most likely left by the murderer",footprintsSprite);
		Item gloves = new Item (glovesPrefab,"Bloody Gloves","Bloody gloves most likely used by the murderer",glovesSprite);
		Item wine = new Item (winePrefab,"Fine Wine","An expensive vintage that's close to 100 years old",wineSprite);
		Item shatteredGlass = new Item (shatteredGlassPrefab,"Shattered Glass","Broken glass shards spread quite close together",shatteredGlassSprite);
		Item shrapnel = new Item (shrapnelPrefab,"Shrapnel","Shrapnel from an explosion or gun being fired",shrapnelSprite);
		Item smellyDeath = new Item (smellyDeathPrefab,"Smelly Ashes","All that remains of the victim",smellyDeathSprite);
		Item spellbook = new Item (spellbookPrefab,"Spellbook","A spellbook used by those who practise in the magic arts",spellbookSprite);
		Item tripwire = new Item (tripwirePrefab,"Tripwire","A used tripwire most likely used to immobilize the victim",tripwireSprite);
		Item chefHat = new Item (chefHatPrefab,"Chef's Hat", "A clean and fresh smelling hat, worn by chefs.",chefHatSprite); 		//ADDITION BY WEDUNNIT
		Item whistle = new Item (whistlePrefab,"Whistle", "A bright, shiny whistle that's as clean as... well.",whistleSprite); 	//ADDITION BY WEDUNNIT
		Item toast = new Item (toastPrefab,"Toast", "A slice of well buttered toast. It's slightly warm.",toastSprite); 			//ADDITION BY WEDUNNIT
		Item stapler = new Item (staplerPrefab,"Stapler", "A bright red stapler, with no staples in it.",staplerSprite); 			//ADDITION BY WEDUNNIT
		Item seaweed = new Item (seaweedPrefab,"Seaweed", "Oceanman, take me by the hand lead me to the land, that you understand.",seaweedSprite); 		//ADDITION BY WEDUNNIT
		Item sandwitch = new Item (sandwitchPrefab,"Sandwich", "A ham sandwich with cheese and lettuce on white bread.",sandwitchSprite); //ADDITION BY WEDUNNIT
		Item purse = new Item (pursePrefab,"Fancy Purse", "A finely made, hand crafted, now-empty purse.",purseSprite); 			//ADDITION BY WEDUNNIT
		Item plunger = new Item (plungerPrefab,"Plunger", "A toilet plunger. It hasn't been used recently.",plungerSprite); 		//ADDITION BY WEDUNNIT
		Item monocle = new Item (monoclePrefab,"Monocle", "A finely made monocle, complete with gold chain.",monocleSprite); 		//ADDITION BY WEDUNNIT
		Item feather = new Item (featherPrefab,"Feather", "A goose feather, apparently freshly plucked.",featherSprite); 			//ADDITION BY WEDUNNIT

		murderWeapons = new MurderWeapon[8] {cutlass,poison,garrote,knife,laserGun,leadPipe,westernPistol,wizardStaff};
		itemClues = new Item [19] {beret,footprints,gloves,wine,shatteredGlass,shrapnel,smellyDeath,spellbook,tripwire, whistle, chefHat,toast,stapler,seaweed,sandwitch,purse,plunger,monocle,feather};
		characters =  new NonPlayerCharacter[10] {pirate,mimes,millionaire,cowgirl,roman,wizard,heman,chubbie,scientist, reginald};
		scenes = new Scene[8] {atrium,lectureTheatre,lakehouse,controlRoom,kitchen,islandOfInteraction,roof,undergroundLab};
	}

	void AssignNPCsToScenes(NonPlayerCharacter[] characters, Scene[] scenes){
		int sceneCounter = 0;
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (characters);
		shuffler.Shuffle (scenes);
		foreach (NonPlayerCharacter character in characters){ 		//For every character in the randomly shuffled array
			scenes [sceneCounter].AddNPCToArray (character);		//Assign a character to a scene
			sceneCounter += 1;										//Increment sceneCounter
			if (sceneCounter >= scenes.Length) {					//If the counter is above the number of scenes cycle to the first scene.  
				sceneCounter = 0;
			}
		}

	}

	void AssignItemsToScenes(Item[] items, Scene[] scenes) {
		int sceneIndex = 0;
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (items);
		shuffler.Shuffle (scenes);
		foreach (Item item in items) {
			scenes [sceneIndex].AddItemToArray (item);
			sceneIndex++;
			if (sceneIndex > scenes.Length) {				
				sceneIndex = 0;
			}
		}
	}

	public void CreateNewGame(PlayerCharacter detective){ //Called when the player presses play
		//Reset values from a previous playthough
		ResetNotebook();
		ResetAll(scenes);
		//Create a Scenario
		scenario = new Scenario (murderWeapons, itemClues, characters);
		scenario.chooseMotive ();
		string motive = scenario.getMotive ();
		murderer = scenario.chooseMurderer ();
		scenario.chooseWeapon ();
		MurderWeapon weapon = scenario.getWeapon ();
		scenario.CreateVerbalClues (motive, weapon, murderer); 
		scenario.BuildCluePools (motive, murderer, weapon);
		scenario.DistributeVerbalClues (murderer);
		itemClues = scenario.getItemCluePool ().ToArray ();
		characters = scenario.getNPCs ();
		verbalClues = scenario.getVerbalCluePool ().ToArray ();
		relevant_items = scenario.getRelevantItems ();
		relevant_verbal_clues = scenario.getRelevantVerbalClues ();
		relevantClues = scenario.getRelevantClues (); 
		//Assign To rooms
		AssignNPCsToScenes (characters,scenes);					//Assigns NPCS to scenes
		AssignItemsToScenes (itemClues,scenes);					//Assigns Items to scenes
		playerCharacter = detective;

		gameScore = 1000;	//ADDITION BY WEDUNNIT
	}
		
	public void Penalise (float penalty){	//ADDITION BY WEDUNNIT
		Debug.Assert(penalty > 0, "Penalise called with penalty less than 0");
		gameScore -= penalty;
	}

	public void GainScore(float bonus){
		Debug.Assert (bonus > 0, "gainScore called with bonus less than 0");
		GameScore += bonus;
		LevelManager ActiveManager = FindObjectOfType<LevelManager> ();
		ActiveManager.OnScoreIncrease ();
	}
		
	public int GetScore (){	//ADDITION BY WEDUNNIT
		int intScore = (int)gameScore;
		return intScore;
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

	private void ResetNotebook(){
		NotebookManager.instance.ResetSelectedClues ();
		NotebookManager.instance.logbook.Reset();	//Reset logbook
		NotebookManager.instance.inventory.Reset();	//Reset inventory
		NotebookManager.instance.UpdateNotebook();
	}

	/// <summary>
	/// Unblocks all characters to allow interrogation if they have been accused.
	/// Called when any clue is added to the logbook
	/// </summary>
	public void UnblockAllCharacters(){
		foreach (Character character in characters) {
			character.AllowCharacterQuestioning ();
		}
	}

		
}