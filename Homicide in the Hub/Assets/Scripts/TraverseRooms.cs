using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TraverseRooms : MonoBehaviour {
	//Used on the map to load the appropriate level.  

	public string level;	//Public to allow for changing in inspector.

	//When the area on the map is clicked load the respective level
	void OnMouseDown() {
		SceneManager.LoadScene(level);
	}
}
