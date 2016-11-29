using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TraverseRooms : MonoBehaviour {

	public string level;
	// Use this for initialization
	void OnMouseDown() {
		SceneManager.LoadScene(level);
		Debug.Log ("Load Level:" + level);
	}
}
