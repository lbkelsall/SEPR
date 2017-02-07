using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Leaderboard : MonoBehaviour {

	public Text scoreGUI;
	public Text nameGUI;

	// Use this for initialization
	void Start () {
		string scoreText = "";
		string nameText = "";
		List<string> nameList = new List<string>();
		List<int> scoreList = new List<int> ();
		using (StreamReader sr = new StreamReader("leaderboard.txt"))
			{
				while (sr.EndOfStream == false) {
					nameList.Add (sr.ReadLine());
					scoreList.Add (int.Parse (sr.ReadLine()));
				}
			}
		Debug.Log (nameList.Count.ToString ());
		List<int> sortedScores = new List<int>(scoreList);
		sortedScores.Sort ();
		sortedScores.Reverse ();
		Debug.Log (sortedScores [0]);
		for(int i=0; i<sortedScores.Count; i++) {
			int forScore = sortedScores [i];
			Debug.Log (forScore);
			int scorePos = scoreList.IndexOf (forScore);
			Debug.Log (scorePos);
			scoreText = scoreText + scoreList [scorePos].ToString () + "\r\n";
			Debug.Log (scoreText);
			nameText = nameText + nameList [scorePos] + "\r\n";
			Debug.Log (nameText);
			scoreList.RemoveAt (scorePos);
			nameList.RemoveAt (scorePos);
		}
		scoreGUI.text = scoreText;
		nameGUI.text = nameText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
