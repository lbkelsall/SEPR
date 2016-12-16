using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	private Item item = null;
	void OnMouseDown(){
		
		NotebookManager.instance.inventory.AddItemToInventory (item);
		NotebookManager.instance.UpdateNotebook();
		Destroy (gameObject);

	}

	public void SetItem(Item item){
		this.item = item;
	}
}
