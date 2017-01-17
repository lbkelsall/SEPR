using UnityEngine;
using System.Collections;

public class InputManager1 : MonoBehaviour {

	public bool isMapvisible = false;
	public bool isMenuvisible = false;
	public bool isNotebookvisible = false;

	public GameObject map;
	public GameObject pauseMenu; 
	private GameObject notebookMenu;
	public GameObject detective; 
	private PlayerMovement playerMovement;
	private bool mapIconPressed = false;
	private bool notebookIconPressed = false;

	void Start () {
		playerMovement = detective.GetComponent<PlayerMovement>();
		Time.timeScale = 1; 
		playerMovement.enabled = true;
		notebookMenu = GameObject.Find("Notebook Canvas").transform.GetChild(0).gameObject;
	}


	void Update () {
		if (!isMenuvisible && !isNotebookvisible) {
			if (Input.GetKeyDown (KeyCode.M) || mapIconPressed) {
				isMapvisible = !isMapvisible;
				if (isMapvisible) {
					StopGame (map);
				} else {
					ResumeGame (map);
				}
				mapIconPressed = false;
			}
		}

		if (!isMapvisible && !isNotebookvisible) {	
			if (Input.GetKeyDown (KeyCode.Escape)) {
				isMenuvisible = !isMenuvisible;
				if (isMenuvisible) {
					StopGame (pauseMenu);
				} else {
					ResumeGame (pauseMenu);
				}
			}

		}

		if (!isMapvisible && !isMenuvisible) {	
			if (Input.GetKeyDown (KeyCode.I) || notebookIconPressed) {
				isNotebookvisible = !isNotebookvisible;
				if (isNotebookvisible) {
					NotebookManager.instance.UpdateNotebook ();
					StopGame (notebookMenu);
				} else {
					ResumeGame (notebookMenu);
				}
				notebookIconPressed = false;
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

	public void MapIconPressed(){
		mapIconPressed = true;
	}

	public void NotebookIconPressed(){
		notebookIconPressed = true;
	}
}
