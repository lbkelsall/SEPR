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

	public void LoadPreviousScene(){
		string previousScene;
		previousScene = InterrogationScript.instance.GetReturnScene ();
		SceneManager.LoadScene (previousScene);
	}
}
