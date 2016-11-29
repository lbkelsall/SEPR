using UnityEngine;
using System.Collections;

public class InputManager1 : MonoBehaviour {

	public bool isMapvisible = false;
	public bool isMenuvisible = false;

	void Start () {

	}
	

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.M)){
			isMapvisible = !isMapvisible
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			isMenuvisible != isMenuvisible
		}

}
