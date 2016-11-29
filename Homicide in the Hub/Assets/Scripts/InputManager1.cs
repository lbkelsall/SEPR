using UnityEngine;
using System.Collections;

public class InputManager1 : MonoBehaviour {

	public bool isMapvisible = false;
	public bool isMenuvisible = false;

	public GameObject map;
	public GameObject pauseMenu; 
	public GameObject detective; 
	private PlayerMovement playerMovement;
	void Start () {
		playerMovement = detective.GetComponent<PlayerMovement>();
	}


	void Update () {
		if (!isMenuvisible) {
			if (Input.GetKeyDown (KeyCode.M)) {
				isMapvisible = !isMapvisible;
				if (isMapvisible) {
					StopGame (map);
				} else {
					ResumeGame (map);
				}
			}
		}

		if (!isMapvisible) {	
			if (Input.GetKeyDown (KeyCode.Escape)) {
				isMenuvisible = !isMenuvisible;
				if (isMenuvisible) {
					StopGame (pauseMenu);
				} else {
					ResumeGame (pauseMenu);
				}
			}

		}

	}

	void StopGame(GameObject menu){
		Time.timeScale = 0; 
		playerMovement.enabled = false;
		menu.SetActive (true);
	}
		
	public void ResumeGame(GameObject menu){
		Time.timeScale = 1; 
		playerMovement.enabled = true;
		menu.SetActive (false);
	}
}
