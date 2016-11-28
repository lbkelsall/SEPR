using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private bool isMapvisible = false;
	private bool isMenuvisible = false;

	public Sprite mapSprite;


	void Start () {
	
	}
	

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.M)){
			isMapvisible = !isMapvisible;
		}
	
		if(Input.GetKeyDown(KeyCode.Escape)){
			isMenuvisible = !isMenuvisible;
		}
	}
		

}
