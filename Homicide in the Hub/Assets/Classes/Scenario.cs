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

	private string[] motives = { "motive1", "motive2", "motive3", "motive4", "motive5", "motive6", "motive7" };

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

	public void CreateVerbalClues() { // this method will take as parameters all the info needed to generate clues (e.g. murderer)
		VerbalClue vc1 = new VerbalClue ("ID1", "D1");
		VerbalClue vc2 = new VerbalClue ("ID2", "D2");
		VerbalClue vc3 = new VerbalClue ("ID3", "D3");
		VerbalClue vc4 = new VerbalClue ("ID4", "D4");
		VerbalClue vc5 = new VerbalClue ("ID5", "D5");
		VerbalClue vc6 = new VerbalClue ("ID6", "D6");
		//VerbalClue vc7 = new VerbalClue ("clue title (for logbook)", "actual clue (e.g. 'I saw x person carrying y weapon'");
		VerbalClue[] verbalClues = new VerbalClue[6] { vc1, vc2, vc3, vc4, vc5, vc6};
		verbal_clues = verbalClues;
	}

	public void BuildCluePools(string motive, NonPlayerCharacter murderer, MurderWeapon weapon) {

		item_clue_pool.Add (weapon);
		relevant_item_clues.Add (weapon);

		if (motive == "motive1") {
			item_clue_pool.Add (item_clues [0]);
			relevant_item_clues.Add (item_clues [0]);
			verbal_clue_pool.Add (verbal_clues [0]);
			relevant_verbal_clues.Add (verbal_clues [0]);
		} else if (motive == "motive2") {
			item_clue_pool.Add (item_clues [1]);
			relevant_item_clues.Add (item_clues [1]);
			verbal_clue_pool.Add (verbal_clues [1]);
			relevant_verbal_clues.Add (verbal_clues [1]);
		} else if (motive == "motive3") {
			item_clue_pool.Add (item_clues [2]);
			relevant_item_clues.Add (item_clues [2]);
			verbal_clue_pool.Add (verbal_clues [2]);
			relevant_verbal_clues.Add (verbal_clues [2]);
		} else if (motive == "motive4") {
			item_clue_pool.Add (item_clues [3]);
			relevant_item_clues.Add (item_clues [3]);
			verbal_clue_pool.Add (verbal_clues [3]);
			relevant_verbal_clues.Add (verbal_clues [3]);
		} else if (motive == "motive5") {
			item_clue_pool.Add (item_clues [4]);
			relevant_item_clues.Add (item_clues [4]);
			verbal_clue_pool.Add (verbal_clues [4]);
			relevant_verbal_clues.Add (verbal_clues [4]);
		} else if (motive == "motive6") {
			item_clue_pool.Add (item_clues [5]);
			relevant_item_clues.Add (item_clues [5]);
			verbal_clue_pool.Add (verbal_clues [5]);
			relevant_verbal_clues.Add (verbal_clues [5]);
		} else if (motive == "motive7") {
			item_clue_pool.Add (item_clues [6]);
			relevant_item_clues.Add (item_clues [6]);
			verbal_clue_pool.Add (verbal_clues [6]);
			relevant_verbal_clues.Add (verbal_clues [6]);
		} else {
			Debug.Log ("ERROR: not choosing motive based clues!");
		}

		if (murderer.getCharacterID() == "Captain Bluebottle") {
			item_clue_pool.Add (item_clues [0]);
			relevant_item_clues.Add (item_clues [0]);
			verbal_clue_pool.Add (verbal_clues [0]);
			relevant_verbal_clues.Add (verbal_clues [0]);
		} else if (murderer.getCharacterID() == "The Mime Twins") {
			item_clue_pool.Add (item_clues [1]);
			relevant_item_clues.Add (item_clues [1]);
			verbal_clue_pool.Add (verbal_clues [1]);
			relevant_verbal_clues.Add (verbal_clues [1]);
		} else if (murderer.getCharacterID() == "Sir Worchester") {
			item_clue_pool.Add (item_clues [2]);
			relevant_item_clues.Add (item_clues [2]);
			verbal_clue_pool.Add (verbal_clues [2]);
			relevant_verbal_clues.Add (verbal_clues [2]);
		} else if (murderer.getCharacterID() == "Jesse Ranger") {
			item_clue_pool.Add (item_clues [3]);
			relevant_item_clues.Add (item_clues [3]);
			verbal_clue_pool.Add (verbal_clues [3]);
			relevant_verbal_clues.Add (verbal_clues [3]);
		} else if (murderer.getCharacterID() == "Celcius Maximus") {
			item_clue_pool.Add (item_clues [4]);
			relevant_item_clues.Add (item_clues [4]);
			verbal_clue_pool.Add (verbal_clues [4]);
			relevant_verbal_clues.Add (verbal_clues [4]);
		} else if (murderer.getCharacterID() == "Randolf the Deep Purple") {
			item_clue_pool.Add (item_clues [5]);
			relevant_item_clues.Add (item_clues [5]);
			verbal_clue_pool.Add (verbal_clues [5]);
			relevant_verbal_clues.Add (verbal_clues [5]);
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