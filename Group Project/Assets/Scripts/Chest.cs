using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
	public Inventory inv;
	void OnTriggerEnter2D(Collider2D co){
		Inventory inv = co.GetComponentInChildren<Inventory>() as Inventory;
		if(inv){
			inv.AddItem (2);
		}
		Destroy (this.gameObject);
	}
}
