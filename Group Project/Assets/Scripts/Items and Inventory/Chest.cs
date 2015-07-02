using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
	public Inventory inv;

	void OnTriggerEnter2D(Collider2D co){
		Inventory inv = co.GetComponentInChildren<Inventory>() as Inventory;
		inv.AddItem (2);
		int r = Random.Range(2, 4);
		for (int i = 0; i < r; i++) {
			int item = Random.Range (3, 16);
			   if(inv){
				inv.AddItem(item);  }
		  }
		Destroy (this.gameObject);
	}
}
