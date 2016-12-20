using UnityEngine;
using System.Collections;

abstract public class Clue : MonoBehaviour {

	private string clueID;
	private string description;

	public Clue(string clueID, string description){
		this.clueID = clueID;
		this.description = description;
	}

	public string getID() {
		return this.clueID;
	}

	public string getDescription() {
		return this.description;
	}

}
