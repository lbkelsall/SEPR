using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private PlayerCharacter detective;
	public GameObject playerObject;
	private SpriteRenderer playerSpriteRenderer;
	public GameObject[] characterSpawnPoints;
	public GameObject[] itemSpawnPoints;
	public float characterScaling = 1;
	public float itemScaling = 1;

	void Start() {
		//Assign correct detective
		playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer> ();
		detective = GameMaster.instance.GetPlayerCharacter(); 
		playerSpriteRenderer.sprite = detective.getSprite ();



		//Get Scene in scene
		string sceneName = SceneManager.GetActiveScene().name;
		Scene scene = GameMaster.instance.GetScene(sceneName);
		AssignCharactersToSpawnPoints (scene);
		AssignItemsToSpawnPoints (scene);
	}

	private void AssignCharactersToSpawnPoints(Scene scene){
		int spawnPointCounter = 0;

		foreach (NonPlayerCharacter character in scene.GetCharacters()){
			GameObject prefab = Instantiate (character.GetPrefab(),characterSpawnPoints [spawnPointCounter].transform.position, Quaternion.identity ) as GameObject;
			prefab.transform.localScale *= characterScaling; 
			spawnPointCounter += 1;
			CharacterInteraction characterInteraction = prefab.GetComponent<CharacterInteraction> ();
			characterInteraction.SetCharacter (character);
		}

	}

	private void AssignItemsToSpawnPoints(Scene scene){
		int itemSpawnPointCounter = 0;
		foreach (Item item in scene.GetItems()) {
			GameObject prefab = Instantiate (item.GetPrefab(),itemSpawnPoints [itemSpawnPointCounter].transform.position, Quaternion.identity ) as GameObject;
			prefab.transform.localScale *= itemScaling; 
			itemSpawnPointCounter += 1;
		}
	}
}
