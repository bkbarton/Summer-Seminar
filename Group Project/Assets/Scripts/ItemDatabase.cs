using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();

	void Awake(){
							//(Name, ID(nothing can be 0), Description, Power, Intelligence, Defence, Item type(Weapon, Consumable, or Armour) 
		//just random items put in database on awake
		items.Add (new Item ("Amulet", 1, "Very Strange", 2, 0,1, Item.ItemType.Armour));
		items.Add (new Item ("Axe", 10, "This is a sturdy axe", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Bow", 3, "Fine bow", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Flamberge",4, "This sword makes you a beast", 10, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Heavy Bow", 5, "This is a strong ancient bow", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Ice Sword", 6, "Chilly", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Light Armour", 7, "This weighs nothing", 2, 0,3, Item.ItemType.Armour));
		items.Add (new Item ("Magic Hat", 8, "I feel smarter already", 2, 10,1, Item.ItemType.Armour));//might delete
		items.Add (new Item ("Majestic Armour", 9, "Best armour NA", 2, 0,10, Item.ItemType.Armour));
		items.Add (new Item ("Potion", 2, "This will heal ", 2, 0,1, Item.ItemType.Consumable));
		items.Add (new Item ("Red Armour", 11, "I like red", 2, 5,5, Item.ItemType.Armour));
		items.Add (new Item ("Silver Armour", 12, "Very sturdy armour", 2, 0,7, Item.ItemType.Armour));
		items.Add (new Item ("Snaga", 13, "This axehas history ", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Strong Sword", 14, "A well crafted sword", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Sword", 15, "I can see the rust ", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Thunder Sword", 16, "Zappy Zap", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("White Shirt", 17, "A nice shirt!", 2, 0,1, Item.ItemType.Armour));
	}
}
