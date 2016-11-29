using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private PlayerCharacter detective;
	public GameObject playerObject;
	private SpriteRenderer playerSpriteRenderer;
	// Update is called once per frame
	void Start() {
		playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer> ();
		detective = GameMaster.instance.getPlayerCharacter(); 
		playerSpriteRenderer.sprite = detective.getSprite ();
	}
}
