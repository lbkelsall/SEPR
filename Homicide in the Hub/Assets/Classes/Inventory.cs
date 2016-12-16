using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory{

	private List<Item> inventory = new List<Item> ();

	public Inventory (){

	}

	public void AddItemToInventory(Item item){
		inventory.Add (item);
	}

	public List<Item> GetInventory(){
		return this.inventory;
	}

	public void Reset(){
		this.inventory.Clear ();
	}

	public int GetListLength(){
		return this.inventory.Count;
	}
}
