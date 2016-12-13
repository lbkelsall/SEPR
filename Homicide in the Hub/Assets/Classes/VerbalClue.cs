using UnityEngine;
using System.Collections;

public class VerbalClue : Clue {

	private NonPlayerCharacter owner;
	public VerbalClue(string clueID, string description,NonPlayerCharacter owner) : base(clueID, description){
		this.owner = owner;
	}
}
