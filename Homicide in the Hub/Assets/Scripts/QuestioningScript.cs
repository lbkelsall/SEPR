using UnityEngine;
using System.Collections;

public class QuestioningScript : MonoBehaviour {

	private PlayerCharacter detective; 

	// Use this for initialization
	void Start () {
		detective = GameMaster.instance.GetPlayerCharacter(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
