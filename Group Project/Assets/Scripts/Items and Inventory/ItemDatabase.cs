using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();

	void Awake(){
							//(Name, ID(nothing can be 0), Description, Power, Intelligence, Defence, Item type(Weapon, Consumable, or Armour) 
		//just random items put in database on awake
		items.Add (new Item ("Amulet", 1, "Very Strange", 0, 0,10, Item.ItemType.Armour));
		items.Add (new Item ("Potion", 2, "This will heal ", 0, 0,20, Item.ItemType.Consumable));
		items.Add (new Item ("Axe", 3, "This is a sturdy axe", 2, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Bow", 4, "Fine bow", 3, 1,0, Item.ItemType.Weapon));
		items.Add (new Item ("Flamberge", 5, "This sword makes you a beast", 10, 3,0, Item.ItemType.Weapon));
		items.Add (new Item ("Heavy Bow", 6, "This is a strong ancient bow", 5, 5,0, Item.ItemType.Weapon));
		items.Add (new Item ("Ice Sword", 7, "Chilly", 6, 10,0, Item.ItemType.Weapon));
		items.Add (new Item ("Light Armour", 8, "This weighs nothing", 0, 2,15, Item.ItemType.Armour));
		items.Add (new Item ("Majestic Armour", 9, "Best armour NA", 0, 10,30, Item.ItemType.Armour));
		items.Add (new Item ("Red Armour", 10, "I like red", 0, 5,35, Item.ItemType.Armour));
		items.Add (new Item ("Silver Armour", 11, "Very sturdy armour", 0, 0,45, Item.ItemType.Armour));
		items.Add (new Item ("Snaga", 12, "This axehas history ", 15, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Strong Sword", 13, "A well crafted sword", 9, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Sword", 14, "I can see the rust ", 3, 0,0, Item.ItemType.Weapon));
		items.Add (new Item ("Thunder Sword", 15, "Zappy Zap", 15, 5,0, Item.ItemType.Weapon));
		items.Add (new Item ("White Shirt", 16, "A nice shirt!", 0, 0,5, Item.ItemType.Armour));
		items.Add (new Item ("Magic Hat", 17, "I feel smarter already", 0, 10,0, Item.ItemType.Armour));//might delete
	}
}
