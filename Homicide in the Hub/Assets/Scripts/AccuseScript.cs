using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AccuseScript : MonoBehaviour {

	private GameObject notebookMenu;
	private Button backButton;
	private Button submitButton;

	private List<Item> inventory; 
	private List<VerbalClue> logbook; 


	public void Start() {
		inventory = NotebookManager.instance.inventory.GetInventory ();
		logbook = NotebookManager.instance.logbook.GetLogbook ();
		notebookMenu = GameObject.Find("Notebook Canvas").transform.GetChild(0).gameObject;
		GameObject backButtonObj = GameObject.FindGameObjectWithTag ("Back");
		backButton = backButtonObj.GetComponent<Button>();
		GameObject submitButtonObj = GameObject.FindGameObjectWithTag ("Submit");
		submitButton = submitButtonObj.GetComponent<Button>();
		backButton.onClick.AddListener (() => BackToMenu ());
		submitButton.onClick.AddListener (() => CompareEvidence ());
	}

	public void OpenorCloseNotebook(bool value){
		NotebookManager.instance.UpdateNotebook ();
		notebookMenu.gameObject.SetActive (value);
	}
		
	private void BackToMenu(){

	}

	private void CompareEvidence(){
		List<Clue> selectedClues = NotebookManager.instance.GetSelectedClues ();
		//CompareLists(selectedClues, )
			
	}

	private bool CompareLists(List<Clue> list1, List<Clue> list2){
		bool match = true;

		for (int i = 0; i < list1.Count; i++) {
			if (!list2.Contains (list1 [i])) {
				match = false;
				return match;
			}
		}
		return match;
	}
}

