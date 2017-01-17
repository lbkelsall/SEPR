using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AccuseScript : MonoBehaviour {

	private GameObject notebookMenu;
	private Button backButton;
	private Button submitButton;
	public GameObject optionsMenu;

	private string character; 

	public void Start() {
		character = InterrogationScript.instance.GetInterrogationCharacter ().getCharacterID();
		NotebookManager.instance.UpdateNotebook ();
		notebookMenu = GameObject.Find("Notebook Canvas").transform.GetChild(0).gameObject;
		notebookMenu.SetActive (true);
		backButton = GameObject.FindGameObjectWithTag ("Back").GetComponent<Button>();
		submitButton = GameObject.FindGameObjectWithTag ("Submit").GetComponent<Button>();
		notebookMenu.SetActive (false);
		backButton.onClick.AddListener (() => BackToMenu ());
		submitButton.onClick.AddListener (() => CompareEvidence ());
	}

	public void OpenNotebook(){
		NotebookManager.instance.UpdateNotebook ();
		notebookMenu.SetActive (true);
	}
		
	private void BackToMenu(){
		notebookMenu.SetActive (false);
		optionsMenu.SetActive (true);
	}

	private void CompareEvidence(){
		//Get Selected Clues
		List<Item> selectedItemClues = NotebookManager.instance.GetSelectedItemClues ();
		List<VerbalClue> selectedVerbalClues = NotebookManager.instance.GetSelectedVerbalClues ();

		//Get required clues
		List<Item> relevantItemClues = GameMaster.instance.GetRelevantItems();
		List<VerbalClue> relevantVerbalClues = GameMaster.instance.GetRelevantVerbalClues();
		if ((CompareItemLists(selectedItemClues,relevantItemClues)) && (CompareVerbalLists(selectedVerbalClues,relevantVerbalClues)) && (character == GameMaster.instance.GetMurderer())){
			//Accusation succesfull
			Debug.Log("Accusation successful!");
		} else {
			Debug.Log ("Accusation failed!");
			//Accusation inccorect or failed

		}
			
	}

	private bool CompareItemLists(List<Item> list1, List<Item> list2){
		bool match = true;

		for (int i = 0; i < list1.Count; i++) {
			if (!list2.Contains (list1 [i])) {
				match = false;
				return match;
			}
		}
		return match;
	}

	private bool CompareVerbalLists(List<VerbalClue> list1, List<VerbalClue> list2){
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

