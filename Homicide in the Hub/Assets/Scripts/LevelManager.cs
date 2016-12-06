using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private PlayerCharacter detective;
	public GameObject playerObject;
	private SpriteRenderer playerSpriteRenderer;
	public GameObject[] characterSpawnPoints;
	public float characterScaling = 1;

	void Start() {
		//Assign correct detective
		playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer> ();
		detective = GameMaster.instance.GetPlayerCharacter(); 
		playerSpriteRenderer.sprite = detective.getSprite ();



		//Get Scene in scene
		string sceneName = SceneManager.GetActiveScene().name;
		Scene scene = GameMaster.instance.GetScene(sceneName);
		AssignCharactersToSpawnPoints (scene);
	}

	private void AssignCharactersToSpawnPoints(Scene scene){
		CharacterInteraction characterInteraction = null;
		GameObject prefab = null;
		int spawnPointCounter = 0;

		foreach (NonPlayerCharacter character in scene.GetCharacters()){
			prefab = Instantiate (character.GetPrefab(),characterSpawnPoints [spawnPointCounter].transform.position, Quaternion.identity ) as GameObject;
			prefab.transform.localScale *= characterScaling; 
			spawnPointCounter += 1;
			characterInteraction = prefab.GetComponent<CharacterInteraction> ();
			characterInteraction.SetCharacter (character);
		}

	}
}
