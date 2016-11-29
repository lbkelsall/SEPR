using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	public void LoadScene(string scene){
		SceneManager.LoadScene(scene);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
