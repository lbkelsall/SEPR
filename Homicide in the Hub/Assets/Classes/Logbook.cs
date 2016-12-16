using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logbook {

	private List<VerbalClue> logbook = new List<VerbalClue> ();

	public Logbook(){
	}

	public void Reset(){
		logbook.Clear ();
	}

	public void AddVerbalClueToLogbook(VerbalClue clue){
		logbook.Add(clue);
	}

	public List<VerbalClue> GetLogbook(){
		return this.logbook;
	}

	public int GetListLength(){
		return logbook.Count;
	}
}
