using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene{
	private string name;
	private List<NonPlayerCharacter> characters = new List<NonPlayerCharacter> ();
	private Item[] items;
	// Use this for initialization
	public Scene (string name, Item[] items = null) {
		this.name = name;
		this.items = items;
	}

	public void AddToArray(NonPlayerCharacter character){
		characters.Add (character);
	}

	public void ResetArray(){
		this.characters.Clear ();
	}

	public string GetName(){
		return this.name;
	}

	public List<NonPlayerCharacter> GetCharacters(){
		return this.characters;
	}
}
