﻿//WEDUNNIT THIS ENTIRE SCRIPT

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	public Text nameField;
	private int endScore;

	// Use this for initialization
	void Start () {
		GameMaster gMaster = FindObjectOfType<GameMaster> ();
		endScore = gMaster.GetScore ();
		Text actualText = scoreText.GetComponent<Text> ();
		actualText.text = "Your score: " + endScore;
		Destroy(GameObject.Find("GlobalScripts")); //ADDITION BY WEDUNNIT
		Destroy(GameObject.Find("NotebookCanvas")); //ADDITION BY WEDUNNIT
	}
	
	public void CloseScreen(){
		string UserInput = nameField.text;
		if (UserInput == "") {
			UserInput = "Some Unnamed Detective";
		}
		using (StreamWriter sw = new StreamWriter ("leaderboard.txt", true)) {
			sw.WriteLine (UserInput);
			sw.WriteLine (endScore.ToString ());
		}
		SceneManager.LoadScene ("Main Menu");
	}
}
