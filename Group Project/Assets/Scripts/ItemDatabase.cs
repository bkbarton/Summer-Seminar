using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();

	void Awake(){
		//just random items put in database on awake
		items.Add (new Item ("Amulet", 2, "Very Strange", 2, 0, Item.ItemType.Armour));
		items.Add (new Item ("White Shirt", 5, "Just an old white shirt", 2, 0, Item.ItemType.Armour));
		items.Add (new Item ("Potion", 1, "Use this to restore 5 health", 2, 0, Item.ItemType.Consumable));
		items.Add (new Item ("Flamberge",3, "This sword makes you a beast", 10, 0, Item.ItemType.Weapon));
		items.Add (new Item ("Magic Hat", 4, "Zappy-ZAP", 2, 0, Item.ItemType.Armour));
	}
}
