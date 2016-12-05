using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private PlayerCharacter detective;
	public GameObject playerObject;
	private SpriteRenderer playerSpriteRenderer;
	public GameObject[] characterSpawnPoints;
	private Scene scene;
	public string sceneName;

	void Start() {
		//Assign correct detective
		playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer> ();
		detective = GameMaster.instance.GetPlayerCharacter(); 
		playerSpriteRenderer.sprite = detective.getSprite ();

		//Get Scene in scene
		scene = GameMaster.instance.GetScene(sceneName);
		AssignCharactersToSpawnPoints ();
	}

	public void AssignCharactersToSpawnPoints(){
		int spawnPointCounter = 0;
		SpriteRenderer spriteRenderer;
		foreach (NonPlayerCharacter character in scene.GetCharacters()){
			spriteRenderer = characterSpawnPoints [spawnPointCounter].GetComponent<SpriteRenderer> ();
			spriteRenderer.sprite = character.getSprite ();
		}
	}
}
