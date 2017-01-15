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

	private string[] motives = { "motive1, motive2, motive3, motive4, motive5, motive6, motive7" };

	public Scenario (MurderWeapon[] murder_weapons, Item[] items, VerbalClue[] verbal, NonPlayerCharacter[] characters)
	{
		weapons = murder_weapons;
		item_clues = items;
		verbal_clues = verbal;
		npcs = characters;
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

		relevant_item_clues = item_clue_pool;
		relevant_verbal_clues = verbal_clue_pool; 

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

	public NonPlayerCharacter[] getNPCs () {
		return npcs;
	}

	public List<Item> getRelevantItems () {
		return relevant_item_clues;
	}

	public List<VerbalClue> getRelevantVerbalClues () {
		return relevant_verbal_clues; 
	} 
}