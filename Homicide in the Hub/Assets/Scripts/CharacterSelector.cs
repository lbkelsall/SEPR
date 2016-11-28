using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour {
	private PlayerCharacter[] detectives; 

	//Detecive variable declaration
	public Sprite chaseHunterSprite;
	public Sprite johnnySlickSprite;
	public Sprite adamFounderSprite;
	private PlayerCharacter chaseHunter;
	private PlayerCharacter johnnySlick;
	private PlayerCharacter adamFounder;

	// Use this for initialization
	void Start () {
		chaseHunter = new PlayerCharacter ("Chase Hunter", chaseHunterSprite, "The Loose Cannon", "Aggressive", "An ill tempered detective who will do whatever it takes to get to the bottom of a crime." );
		johnnySlick = new PlayerCharacter ("Johnny Slick", johnnySlickSprite, "The Greaseball", "Wisecracking", "A witty detective who finds the comedic value in everything... even death apparently." );
		adamFounder = new PlayerCharacter ("Adam Founder", adamFounderSprite, "Good Cop", "By the Book", "A by the book cop who uses proper detective techniques to solve mysteries" );
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
