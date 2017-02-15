using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

public class Leaderboard : MonoBehaviour {

	public Text scoreGUI;
	public Text nameGUI;

    private List<string> nameList;
    private List<int> scoreList;

    // Use this for initialization
	void Start () {
		string scoreText = "";
		string nameText = "";
		nameList = new List<string>();
		scoreList = new List<int> ();
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
		//Debug.Log (sortedScores [0]);
		foreach (int score in sortedScores)
		{
		    Debug.Log (score);
		    int scorePos = scoreList.IndexOf (score);
		    Debug.Log (scorePos);
		    scoreText = scoreText + scoreList [scorePos] + "\r\n";
		    Debug.Log (scoreText);
		    nameText = nameText + nameList [scorePos] + "\r\n";
		    Debug.Log (nameText);
		    scoreList.RemoveAt (scorePos);
		    nameList.RemoveAt (scorePos);
		}
		if (scoreGUI != null) {
			scoreGUI.text = scoreText;
		}
		if (nameGUI != null) {
			nameGUI.text = nameText;
		}
	}

    public int GetScoreCount()
    {
        if (scoreList != null)
        {
            return scoreList.Count;
        }
        return 0;
    }

    public List<string> GetScoreNames()
    {
        if (nameList != null)
        {
            return nameList;
        }
        return new List<string>();
    }


    public List<int> GetScores()
    {
        if (scoreList != null)
        {
            return scoreList;
        }
        return new List<int>();
    }
}
