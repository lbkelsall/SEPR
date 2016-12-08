using UnityEngine;
using System.Collections;

public class NonPlayerCharacter : Character {

	private bool isMurderer = false; 
	private GameObject prefab;
	// Use this for initialization

	public NonPlayerCharacter (string characterID, Sprite sprite, string nickname, GameObject prefab) :  base(characterID, sprite, nickname) {
		this.prefab = prefab;
	}

	public bool IsMurderer(){
		return this.isMurderer;
	}

	public void SetAsMurderer(){
		this.isMurderer = true;
	}

	public GameObject GetPrefab(){
		return this.prefab;
	}
		
}
