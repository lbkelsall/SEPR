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
	public Sprite questionMark;

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
		//Display Items
		for (int i = 0; i < (inventory.Count); i++) {
			clueTexts [topOfList].text = " - "+inventory[i].getID ();
		}

		//Display Verbal Clues
		topOfList = inventory.Count;
		for (int j = 0; j < (logbook.Count); j++) {
			clueTexts [topOfList].text = " - "+logbook[j].getID ();
			topOfList += 1;
		}

		//Reset not used items from previous playthrough
		for (int z = 0; z < (20-(inventory.Count + logbook.Count)); z++) {
			clueTexts [topOfList].text = "";
			topOfList += 1;
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
			clueImage.sprite = questionMark;
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

