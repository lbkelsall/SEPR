using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene{
	private string name;
	private List<NonPlayerCharacter> characters = new List<NonPlayerCharacter> ();
	private List<Item> items = new List<Item> ();
	// Use this for initialization
	public Scene (string name) {
		this.name = name;
	}

	public void AddNPCToArray(NonPlayerCharacter character){
		characters.Add (character);
	}

	public void AddItemToArray(Item item){
		items.Add (item);
	}

	public void ResetScene(){
		this.characters.Clear ();
		this.items.Clear ();
	}

	public string GetName(){
		return this.name;
	}

	public List<NonPlayerCharacter> GetCharacters(){
		return this.characters;
	}
}
