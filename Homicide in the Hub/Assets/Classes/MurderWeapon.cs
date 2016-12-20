using UnityEngine;
using System;

public class MurderWeapon : Item {

	private String steve_description;

	public MurderWeapon(GameObject prefab, string clueID, string description, Sprite sprite, String steve_description) 
		: base(clueID, description, prefab, sprite) {
		this.steve_description = steve_description;
	}

	public String getSteveDescription() {
		return this.steve_description;
	}
}

