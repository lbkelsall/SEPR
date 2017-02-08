//WEDUNNIT THIS ENTIRE SCRIPT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	public Text nameField;
	private int endScore;

	// Use this for initialization
	void Start () {
		GameMaster gMaster = FindObjectOfType<GameMaster> ();
		endScore = (int)gMaster.GetScore ();
		Text actualText = scoreText.GetComponent<Text> ();
		actualText.text = "Your score: " + endScore.ToString ();
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
