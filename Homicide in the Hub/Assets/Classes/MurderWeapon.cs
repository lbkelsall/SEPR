using UnityEngine;
using System.Collections;

public class MurderWeapon : Item {

	private string steve_description;

	public MurderWeapon(GameObject prefab, string clueID, string description, Sprite sprite, string steve_description) 
		: base(prefab, clueID, description, sprite) {
		this.steve_description = steve_description;
	}

	public string getSteveDescription() {
		return this.steve_description;
	}
}

