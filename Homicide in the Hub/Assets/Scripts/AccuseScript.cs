using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class AccuseScript : MonoBehaviour {

	private GameObject notebookMenu;
	private Button backButton;
	private Button submitButton;
	public GameObject optionsMenu;
	public GameObject verbal;
	public Text verbalText;

	private NonPlayerCharacter character; 

	public void Start() {
		character = InterrogationScript.instance.GetInterrogationCharacter();
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

		bool accusation = true;
		//Get Selected Clues
		List<Item> selectedItemClues = NotebookManager.instance.GetSelectedItemClues ();
		List<VerbalClue> selectedVerbalClues = NotebookManager.instance.GetSelectedVerbalClues ();

		//Get required clues
		List<Item> relevantItemClues = GameMaster.instance.GetRelevantItems ();
		List<VerbalClue> relevantVerbalClues = GameMaster.instance.GetRelevantVerbalClues ();

		foreach (Item clue in selectedItemClues) {
			if (!relevantItemClues.Contains (clue)) {
				accusation = false;
			} 
		}
		foreach (VerbalClue clue in selectedVerbalClues) {
			if (!relevantVerbalClues.Contains(clue)) {
				accusation = false;
			}
		}

		if ((accusation == true) && (character.IsMurderer ())) {
			notebookMenu.SetActive (false);
			SceneManager.LoadScene ("Win Screen");
		} else {
			notebookMenu.SetActive (false);
			verbal.SetActive (true);
			verbalText.text = "You don't have enough evidence to accuse me of murder!";

		}
	}

}

