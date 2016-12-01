using UnityEngine;
using System.Collections;

public class Scene{
	private string name;
	private NonPlayerCharacter[] characters;
	private Item[] items;
	// Use this for initialization
	public Scene (string name,NonPlayerCharacter[] characters = null, Item[] items = null) {
		this.name = name;
		this.characters = characters;
		this.items = items;
	}

}
