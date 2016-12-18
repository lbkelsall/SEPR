using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AccuseScript : MonoBehaviour {

	public Text[] clueTexts = new Text[20]; 
	public Button[] clueButtons = new Button[20]; 
	public Text clueNameText;
	public Text clueDescriptionText;
	public Image clueImage;
	private List<Clue> selectedClues = new List<Clue>();
	private int currentlySelectedClueIndex; 
	public int requiredNumberOfClues = 3;
	public Text clueTitle;
	public Button selectButton;

	private List<Item> inventory; 
	private List<VerbalClue> logbook; 

	public void Start() {
		inventory = NotebookManager.instance.inventory.GetInventory ();
		logbook = NotebookManager.instance.logbook.GetLogbook ();
		UpdateNotebook ();
		selectButton.interactable = false;
	}

	public void UpdateNotebook(){
		int topOfList = 0;
		//Update Listing
		for (int i = 0; i < (inventory.Count); i++) {
			clueTexts [i].text = " - "+inventory[i].getID ();
			topOfList = i;
		}
		for (int j = topOfList; j < (logbook.Count); j++) {
			clueTexts [j].text = " - "+logbook[j].getID ();
		}
		clueTitle.text = "Clues (" + (inventory.Count + logbook.Count) + "/" + requiredNumberOfClues + ")";
	}


	public void ShowClueInfomation(int index){
		currentlySelectedClueIndex = index; 
		if (index < inventory.Count) {
			Item clue = inventory [index];
			clueNameText.text = clue.getID ();  
			clueDescriptionText.text = clue.getDescription ();
			clueImage.sprite = clue.GetSprite ();
		} else {
			VerbalClue clue = logbook[index - inventory.Count];
			clueNameText.text = clue.getID ();  
			clueDescriptionText.text = clue.getDescription ();
			clueImage.sprite = null;
		}
		selectButton.interactable = true;
	}

	public void AddToSelectedClues(){
		if (currentlySelectedClueIndex < inventory.Count) {
			Item clue = inventory [currentlySelectedClueIndex];
			selectedClues.Add (clue);
		} else {
			VerbalClue clue = logbook [currentlySelectedClueIndex];
			selectedClues.Add (clue);
		}
		Debug.Log (selectedClues[0].getID());
	}

}

