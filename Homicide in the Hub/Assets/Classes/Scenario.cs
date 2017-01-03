using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Scenario
{

	private MurderWeapon[] weapons;
	private Item[] item_clues;
	private VerbalClue[] verbal_clues;
	private NonPlayerCharacter[] npcs;

	private List<Item> item_clue_pool = new List<Item> ();
	private List<VerbalClue> verbal_clue_pool = new List<VerbalClue> ();
	private MurderWeapon weapon;

	private string[] motives = { "motive1, motive2, motive3, motive4, motive5, motive6, motive7" };

	public Scenario () {
	}

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
	private MurderWeapon cutlass;
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

	public void init() {

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

		cutlass = new MurderWeapon(cutlassPrefab,"Cutlass","A worn and well used cutlass",cutlassSprite, "SD");
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

		weapons = new MurderWeapon[8] {cutlass,poison,garrote,knife,laserGun,leadPipe,westernPistol,wizardStaff};
		item_clues = new Item [9] {beret,footprints,gloves,wine,shatteredGlass,shrapnel,smellyDeath,spellbook,tripwire};
		npcs =  new NonPlayerCharacter[6] {pirate,mimes,millionaire,cowgirl,roman,wizard};
		verbal_clues = new VerbalClue[7] { vc1, vc2, vc3, vc4, vc5, vc6, vc7 };
	}	 

	public void chooseWeapon() {
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (weapons);
		weapon = weapons [0];
	}
			

	public string chooseMotive() {
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (motives);
		return motives [0];
	}

	public NonPlayerCharacter chooseMurderer() {
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (npcs);
		NonPlayerCharacter murderer = npcs [0];
		murderer.SetAsMurderer ();
		return murderer;
	}


	public void BuildCluePools(string motive, NonPlayerCharacter murderer, MurderWeapon weapon) {

		item_clue_pool.Add (weapon);

		switch (motive) {
		case ("motive1"):
			item_clue_pool.Add (item_clues [0]);
			verbal_clue_pool.Add (verbal_clues [0]);
			break;
		case ("motive2"):
			item_clue_pool.Add (item_clues [1]);
			verbal_clue_pool.Add (verbal_clues [1]);
			break;
		case ("motive3"):
			item_clue_pool.Add (item_clues [2]);
			verbal_clue_pool.Add (verbal_clues [2]);
			break;
		case ("motive4"):
			item_clue_pool.Add (item_clues [3]);
			verbal_clue_pool.Add (verbal_clues [3]);
			break;
		case ("motive5"):
			item_clue_pool.Add (item_clues [4]);
			verbal_clue_pool.Add (verbal_clues [4]);
			break;
		case ("motive6"):
			item_clue_pool.Add (item_clues [5]);
			verbal_clue_pool.Add (verbal_clues [5]);
			break;
		case ("motive7"):
			item_clue_pool.Add (item_clues [6]);
			verbal_clue_pool.Add (verbal_clues [6]);
			break;
		}

		if (murderer.getCharacterID() == "Captain Bluebottle") {
			item_clue_pool.Add (item_clues [0]);
			verbal_clue_pool.Add (verbal_clues [0]);
		} else if (murderer.getCharacterID() == "The Mime Twins") {
			item_clue_pool.Add (item_clues [1]);
			verbal_clue_pool.Add (verbal_clues [1]);
		} else if (murderer.getCharacterID() == "Sir Worchester") {
			item_clue_pool.Add (item_clues [2]);
			verbal_clue_pool.Add (verbal_clues [2]);
		} else if (murderer.getCharacterID() == "Jesse Ranger") {
			item_clue_pool.Add (item_clues [3]);
			verbal_clue_pool.Add (verbal_clues [3]);
		} else if (murderer.getCharacterID() == "Celcius Maximus") {
			item_clue_pool.Add (item_clues [4]);
			verbal_clue_pool.Add (verbal_clues [4]);
		} else if (murderer.getCharacterID() == "Randolf the Deep Purple") {
			item_clue_pool.Add (item_clues [5]);
			verbal_clue_pool.Add (verbal_clues [5]);
		}

		while (item_clue_pool.Count() < 6) {
			int index = Random.Range (0, item_clues.Count());
			if (item_clue_pool.Contains (item_clues [index]) == false) {
				item_clue_pool.Add (item_clues [index]);
			}
		}

		while (verbal_clue_pool.Count() < 3) {
			int index = Random.Range (0, verbal_clues.Count());
			if (verbal_clue_pool.Contains (verbal_clues [index]) == false) {
				verbal_clue_pool.Add (verbal_clues [index]);
			}
		}

	}

	public void DistributeVerbalClues() {
		int index = 0;
		while (index < verbal_clue_pool.Count()) {
			NonPlayerCharacter character = npcs [Random.Range (0, npcs.Count ())];
			if (character.getVerbalClue() == null) {
				character.setVerbalClue (verbal_clue_pool [index]);
				verbal_clue_pool [index].setOwner (character); 
				index++;
			}
		}
	}

	public List<Item> getItemCluePool () {
		return item_clue_pool; 
	}

	public List<VerbalClue> getVerbalCluePool () {
		return verbal_clue_pool;
	}

	public MurderWeapon getWeapon () {
		return weapon;
	}

	public NonPlayerCharacter[] getNPCs () {
		return npcs;
	}
}