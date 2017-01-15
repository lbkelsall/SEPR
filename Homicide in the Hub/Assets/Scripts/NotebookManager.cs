using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour {

	public Inventory inventory = new Inventory();
	public Logbook logbook = new Logbook();
	public static NotebookManager instance = null;

	public Text[] clueTexts = new Text[20]; 
	public Button[] clueButtons = new Button[20]; 
	public Text clueNameText;
	public Text clueDescriptionText;
	public Image clueImage;
	public int requiredNumberOfClues = 3;
	public Text clueTitle;
	public Sprite questionMark;

	void Awake () {  //Makes this a singleton class on awake
		if (instance == null) { //Does an instance already exist?
			instance = this;	//If not set instance to this
		} else if (instance != this) { //If it already exists and is not this then destroy this
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject); //Set this to not be destroyed when reloading scene
	}

	public void UpdateNotebook(){
		int topOfList = 0;
		//Update Listing
		//Display Items
		for (int i = 0; i < (inventory.GetInventory ().Count); i++) {
			clueTexts [topOfList].text = " - "+inventory.GetInventory () [i].getID ();
		}

		//Display Verbal Clues
		topOfList = inventory.GetInventory ().Count;
		for (int j = 0; j < (logbook.GetLogbook().Count); j++) {
			clueTexts [topOfList].text = " - "+logbook.GetLogbook () [j].getID ();
			topOfList += 1;
		}

		//Reset not used items from previous playthrough
		for (int z = 0; z < (20-(inventory.GetInventory ().Count + logbook.GetLogbook ().Count)); z++) {
			clueTexts [topOfList].text = "";
			topOfList += 1;
		}
		clueTitle.text = "Clues (" + (inventory.GetListLength () + logbook.GetListLength ()) + "/" + requiredNumberOfClues + ")";
	}
		
	public void ShowClueInfomation(int index){

		//Check if the clue is in the given range. 
		if (index < inventory.GetInventory ().Count+logbook.GetLogbook ().Count){
			//Detect if it is an item
			if (index < inventory.GetInventory ().Count) {
				Item clue = inventory.GetInventory () [index];
				clueNameText.text = clue.getID ();  
				clueDescriptionText.text = clue.getDescription ();
				clueImage.sprite = clue.GetSprite ();
			
				//Otherwise it must be a Verbal Clue
			} else {
				VerbalClue clue = logbook.GetLogbook () [index - inventory.GetInventory ().Count];
				clueNameText.text = clue.getID ();  
				clueDescriptionText.text = clue.getDescription ();
				clueImage.sprite = questionMark;
			}
		}
	}
}
