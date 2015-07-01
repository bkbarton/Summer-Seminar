using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	//fields for items
	public string 		itemName;
	public int 			itemID;
	public string		itemDesc;
	public Texture2D	itemIcon;
	public int			itemPower;
	public int			itemInt;
	public int			itemDef;
	public ItemType		itemType;

	public enum ItemType{
		Weapon,
		Armour,
		Consumable
	}

	public Item(string name, int id, string desc, int power, int Int,int def,  ItemType type ){
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D>(name);
		itemPower = power;
		itemInt = Int;
		itemDef = def;
		itemType = type;
	}
	public Item(){
	
	}
}
