using UnityEngine;
using System.Collections;

public class InputManager1 : MonoBehaviour {

	public bool isMapvisible = false;
	public bool isMenuvisible = false;

	public GameObject map;

	void Start () {



	}


	void Update () {
	
		if(Input.GetKeyDown(KeyCode.M)){
			isMapvisible = !isMapvisible;
		}

		if (isMapvisible == true) {
			map.SetActive (true);
		} else {
			map.SetActive (false);

		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			isMenuvisible = !isMenuvisible;
		}

}
}
