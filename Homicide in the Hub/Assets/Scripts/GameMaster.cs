using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	//Arrays 
	public static GameMaster instance = null;
	private NonPlayerCharacter[] characters;
	private Item[] items; 
	private Scene[] scenes;

	//Detecive variable declaration
	public Sprite chaseHunterSprite;
	public Sprite johnnySlickSprite;
	public Sprite adamFounderSprite;
	private PlayerCharacter chaseHunter;
	private PlayerCharacter johnnySlick;
	private PlayerCharacter adamFounder;

	//NPC variable declaration


	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
		InitGame();
	}

	void InitGame(){
		//Create Detectives 
		chaseHunter = new PlayerCharacter ("Chase Hunter", chaseHunterSprite, "The Loose Cannon", "Aggressive", "An ill tempered detective who will do whatever it takes to get to the bottom of a crime." );
		johnnySlick = new PlayerCharacter ("Johnny Slick", johnnySlickSprite, "The Greaseball", "Wisecracking", "A witty detective who finds the comedic value in everything... even death apparently." );
		adamFounder = new PlayerCharacter ("Adam Founder", adamFounderSprite, "Good Cop", "By the Book", "A by the book cop who uses proper detective techniques to solve mysteries" );

		//Create NPC's

	}

	void AssignNPCsToScenes(){

	}

	void AssignItemsToScenes(){

	}
}
