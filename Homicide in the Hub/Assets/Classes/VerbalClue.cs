using UnityEngine;
using System.Collections;

public class VerbalClue : Clue {

	private NonPlayerCharacter owner;
	public VerbalClue(string clueID, string description) : base(clueID, description){
	}

	public void setOwner (NonPlayerCharacter owner) {
		this.owner = owner;
	}

	public NonPlayerCharacter getOwner () {
		return this.owner;
	}

}
