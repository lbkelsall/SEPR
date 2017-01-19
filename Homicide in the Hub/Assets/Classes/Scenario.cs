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
	private List<Item> relevant_item_clues = new List<Item> ();
	private List<VerbalClue> relevant_verbal_clues = new List<VerbalClue> ();
	private MurderWeapon weapon;
	private string motive;

	private string[] motives = { "homewrecker", "loanshark", "promotion", "unfriended", "blackmail", "avenge_friend", "avenge_pet" };

	public Scenario (MurderWeapon[] murder_weapons, Item[] items, NonPlayerCharacter[] characters)
	{
		weapons = murder_weapons;
		item_clues = items;
		npcs = characters;
	}

	public void chooseWeapon() {
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (weapons);
		weapon = weapons [0];
	}
			

	public void chooseMotive() {
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (motives);
		motive = motives [0];
	}

	public NonPlayerCharacter chooseMurderer() {
		Shuffler shuffler = new Shuffler ();
		shuffler.Shuffle (npcs);
		NonPlayerCharacter murderer = npcs [0];
		murderer.SetAsMurderer ();
		return murderer;
	}

	public void CreateVerbalClues(string motive, MurderWeapon weapon, NonPlayerCharacter murderer) {

		string murderer_name = murderer.getCharacterID ();
		string weapon_name = weapon.getID ();

		VerbalClue disposing_of_weapon = new VerbalClue ("Disposing of a Weapon", "I saw"+murderer_name+"trying to " +
			"dispose of a"+weapon_name+".");

		string old_friends_description = "The victim and"+murderer_name+"used to be good friends, but recently fell " +
			"out with one another";
		string motive_clause = ".";
		if (motive == "homewrecker") {
			string partner_gender;
			int binary = Random.Range (0, 1);
			if (binary == 0) {
				partner_gender = "wife";
			} else {
				partner_gender = "husband";
			}
			motive_clause = "because the victim slept with their"+partner_gender+".";  
		}
		if (motive == "loanshark") {
			motive_clause = "because"+murderer_name+"was in debt to the victim."; 
		}
		if (motive == "promotion") {
			motive_clause = "because they were in competition with one another at work.";
		}
		if (motive == "unfriended") {
			motive_clause = "because the victim unfriended"+murderer_name+"on Facebook.";
		}
		if (motive == "blackmail") {
			motive_clause = "because the victim knew"+murderer_name+"'s darkest secret.";
		}
		if (motive == "avenge_friend") {
			motive_clause = "because"+murderer_name+"believed that the victim was responsible for the death of a friend."; 
		}
		if (motive == "avenge_pet") {
			string species;
			int rand = Random.Range (0, 4);
			if (rand == 0) {
				species = "parrot";
			} else if (rand == 1) {
				species = "chihuahua";
			} else if (rand == 2) {
				species = "iguana";
			} else if (rand == 3) {
				species = "goldfish";
			} else {
				species = "rattlesnake";
			}
			string cause_of_death;
			rand = Random.Range (0,4);
			if (rand == 0) {
				cause_of_death = "starvation";
			} else if (rand == 1) {
				cause_of_death = "loneliness";
			} else if (rand == 2) {
				cause_of_death = "a broken heart";
			} else if (rand == 3) {
				cause_of_death = "boredom";
			} else {
				cause_of_death = "electrocution";
			}
			motive_clause = "because the victim was looking after"+murderer_name+"'s"+species+"when it " +
				"died of"+cause_of_death+".";  
		}
		old_friends_description += motive_clause;
		VerbalClue old_friends = new VerbalClue ("Old Friends", old_friends_description);

		VerbalClue old_enemies = new VerbalClue ("Old Enemies", "Rumour is that the victim had an unpleasant " +
			"history with"+murderer_name+".");

		VerbalClue last_seen_with = new VerbalClue ("Last Seen With", "I saw the victim alone with"+murderer_name+"just a few " +
			"minutes before their body was discovered.");

		motive_clause = ".";
		if (motive == "homewrecker") {
			string partner_gender;
			int binary = Random.Range (0, 1);
			if (binary == 0) {
				partner_gender = "wife";
			} else {
				partner_gender = "husband";
			}
			motive_clause = "the victim having slept with their"+partner_gender+".";  
		}
		if (motive == "loanshark") {
			motive_clause = murderer_name+"being in debt to the victim."; 
		}
		if (motive == "promotion") {
			motive_clause = "them being in competition with one another at work.";
		}
		if (motive == "unfriended") {
			motive_clause = "the victim unfriending"+murderer_name+"on Facebook.";
		}
		if (motive == "blackmail") {
			motive_clause = "the victim having found out"+murderer_name+"'s darkest secret.";
		}
		if (motive == "avenge_friend") {
			motive_clause = murderer_name+"believing that the victim was responsible for the death of a friend."; 
		}
		if (motive == "avenge_pet") {
			string species;
			int rand = Random.Range (0, 4);
			if (rand == 0) {
				species = "parrot";
			} else if (rand == 1) {
				species = "chihuahua";
			} else if (rand == 2) {
				species = "iguana";
			} else if (rand == 3) {
				species = "goldfish";
			} else {
				species = "rattlesnake";
			}
			string cause_of_death;
			rand = Random.Range (0,4);
			if (rand == 0) {
				cause_of_death = "starvation";
			} else if (rand == 1) {
				cause_of_death = "loneliness";
			} else if (rand == 2) {
				cause_of_death = "a broken heart";
			} else if (rand == 3) {
				cause_of_death = "boredom";
			} else {
				cause_of_death = "electrocution";
			}
			motive_clause = "the victim being responsible for looking after"+murderer_name+"'s"+species+"when it " +
				"died of"+cause_of_death+".";  
		}
		string altercation_location;
		int r = Random.Range (0, 4);
		if (r == 0) {
			altercation_location = "in the car park";
		} else if (r == 1) {
			altercation_location = "at the bar";
		} else if (r == 2) {
			altercation_location = "in the underground laboratory";
		} else if (r == 3) {
			altercation_location = "on the helipad";
		} else {
			altercation_location = "in glasshouse";
		}
		VerbalClue altercation = new VerbalClue ("An Altercation", "I heard that"+murderer_name+"and the victim had an altercation" +
			"in the"+altercation_location+". Apparently it had something to do with"+motive_clause);

		int random = Random.Range (0, npcs.Count ());
		string character_name = npcs [random].getCharacterID ();
		VerbalClue changed_story = new VerbalClue ("Stories Have Changed", murderer_name+"told me that the last time they saw the" +
			"victim was before 8pm, but told"+character_name+"they had spoken to the victim after 9pm.");

		verbal_clues = new VerbalClue[6] {
			old_friends,
			altercation,
			disposing_of_weapon,
			old_enemies,
			last_seen_with,
			changed_story
		};
	}

	public void BuildCluePools(string motive, NonPlayerCharacter murderer, MurderWeapon weapon) {

		item_clue_pool.Add (weapon);
		relevant_item_clues.Add (weapon);

		int pick_motive_clue = Random.Range (0, 1); // 'old friends' or 'altercation'
		if (motive == "homewrecker") {
			relevant_item_clues.Add (item_clues [pick_motive_clue]);
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
		} else if (motive == "loanshark") {
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_motive_clue]);
		} else if (motive == "promotion") {
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_motive_clue]);
		} else if (motive == "unfriended") {
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_motive_clue]);
		} else if (motive == "blackmail") {
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_motive_clue]);
		} else if (motive == "avenge_friend") {
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_motive_clue]);
		} else if (motive == "avenge_pet") {
			verbal_clue_pool.Add (verbal_clues [pick_motive_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_motive_clue]);
		}

		int pick_weapon_clue = Random.Range (2, 5);
		if (murderer.getCharacterID() == "Captain Bluebottle") {
			item_clue_pool.Add (item_clues [4]); // shattered glass
			relevant_item_clues.Add (item_clues [4]);
			verbal_clue_pool.Add (verbal_clues [pick_weapon_clue]);
			relevant_verbal_clues.Add (verbal_clues [pick_weapon_clue ]);
		} else if (murderer.getCharacterID() == "The Mime Twins") {
			item_clue_pool.Add (item_clues [0]); // beret
			relevant_item_clues.Add (item_clues [0]);
			verbal_clue_pool.Add (verbal_clues [pick_weapon_clue ]);
			relevant_verbal_clues.Add (verbal_clues [pick_weapon_clue ]);
		} else if (murderer.getCharacterID() == "Sir Worchester") {
			item_clue_pool.Add (item_clues [2]); // gloves
			relevant_item_clues.Add (item_clues [2]);
			verbal_clue_pool.Add (verbal_clues [pick_weapon_clue ]);
			relevant_verbal_clues.Add (verbal_clues [pick_weapon_clue ]);
		} else if (murderer.getCharacterID() == "Jesse Ranger") {
			item_clue_pool.Add (item_clues [8]); // tripwire
			relevant_item_clues.Add (item_clues [8]);
			verbal_clue_pool.Add (verbal_clues [pick_weapon_clue ]);
			relevant_verbal_clues.Add (verbal_clues [pick_weapon_clue ]);
		} else if (murderer.getCharacterID() == "Celcius Maximus") {
			item_clue_pool.Add (item_clues [3]); // wine
			relevant_item_clues.Add (item_clues [3]);
			verbal_clue_pool.Add (verbal_clues [pick_weapon_clue ]);
			relevant_verbal_clues.Add (verbal_clues [pick_weapon_clue]);
		} else if (murderer.getCharacterID() == "Randolf the Deep Purple") {
			item_clue_pool.Add (item_clues [7]); // spellbook
			relevant_item_clues.Add (item_clues [7]);
			verbal_clue_pool.Add (verbal_clues [pick_weapon_clue ]);
			relevant_verbal_clues.Add (verbal_clues [pick_weapon_clue ]);
		}

		while (item_clue_pool.Count() < 6) {
			int index = Random.Range (0, item_clues.Count());
			if (item_clue_pool.Contains (item_clues [index]) == false) {
				item_clue_pool.Add (item_clues [index]);
			}
		}
			
		// add 'red herring' verbal clue
		int weapon_index = Random.Range(0,weapons.Count());
		string red_herring_weapon = weapons [weapon_index].getID ();
		while (red_herring_weapon == weapon.getID() ) {
			weapon_index = Random.Range(0,weapons.Count());
			red_herring_weapon = weapons [weapon_index].getID ();
		}
		int npc_index = Random.Range(0,npcs.Count());
		string red_herring_character = npcs [npc_index ].getCharacterID  ();
		while (red_herring_character == murderer.getCharacterID () ) {
			npc_index = Random.Range(0,npcs.Count());
			red_herring_character = npcs [npc_index ].getCharacterID ();
		}

		VerbalClue police_failure = new VerbalClue ("Lack of Evidence", "The police told me they think the victim was killed " +
		                            "using a" + red_herring_weapon + ", but they can’t find any evidence of one.");

		VerbalClue shifty_looking = new VerbalClue ("Looking Shifty", "I think I saw"+red_herring_character+"acting suspiciously." );

		VerbalClue[] red_herring_verbal_clues = new VerbalClue[2] { police_failure, shifty_looking };
		int herring_index = Random.Range (0,1);
		verbal_clue_pool.Add (red_herring_verbal_clues [herring_index]);
	}

	public void DistributeVerbalClues() {
		int index = 0;
		while (index < verbal_clue_pool.Count()) {
			NonPlayerCharacter character = npcs [Random.Range (0, npcs.Count ())];
			if (character.getVerbalClue() == null) {
				character.setVerbalClue (verbal_clue_pool [index]);
				verbal_clue_pool [index].SetOwner (character); 
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

	public string getMotive() {
		return motive;
	}

	public NonPlayerCharacter[] getNPCs () {
		return npcs;
	}

	public List<Item> getRelevantItems () {
		return relevant_item_clues;
	}

	public List<VerbalClue> getRelevantVerbalClues () {
		return relevant_verbal_clues; 
	}

	public List<Clue> getRelevantClues () {
		List<Clue> relevant_clues = new List<Clue> ();

		for (int i = 0; (relevant_verbal_clues.Count) > i; i++) {
			relevant_clues.Add (relevant_verbal_clues [i]);
		}
		for (int i = 0; (relevant_item_clues.Count) > i; i++) {
			relevant_clues.Add (relevant_item_clues [i]);
		}
		return relevant_clues;
	}
}