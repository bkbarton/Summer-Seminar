
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public  class Inventory : MonoBehaviour {
	//variables
	public GUISkin 		skin;
	public int 			slotsX, slotsY;
	public List<Item> 	 inventory = new List<Item>();
	public List<Item>	 equipment = new List<Item> ();
	public List<Item>	 slots = new List<Item> ();
	private bool	 	showInventory;
	private bool		showEquip;
	private bool		showToolTip;
	private string 		tooltip;
	private ItemDatabase database; 
	private bool		draggingItem;
	private Item		draggedItem;
	private int			previousIndex;

	// Use this for initialization
	void Start () {
		//start by setting max inventory based on slots
		for(int i = 0; i < (slotsX * slotsY); i++){
			slots.Add (new Item());
			inventory.Add (new Item());
		}
		equipment.Add (new Item ()); //weapon
		equipment.Add (new Item ()); //armour
		//Can add items here to start off with them 
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase> ();
		AddItem (1);
		AddItem (3);
		AddItem (10);
	
	}
	void Update(){
		//If "i" is pressed, inventory will pop up 
		if(Input.GetButtonDown ("Inventory")){
			showInventory = !showInventory;
		}
		if (Input.GetButtonDown ("Character")) {
			showEquip  = !showEquip;
		}
	
	}
	//Responsible for showing the GUI
	void OnGUI(){
		tooltip = "";
		GUI.skin = skin;
			if(showInventory){
				DrawInventory();
			    if (showToolTip) {
				//tool tip will pop up 
					GUI.Box (new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 100), tooltip);
					}
			}
		if (draggingItem) {
			//will show item icon while dragging
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 25, 25), draggedItem.itemIcon);
		}

		if (showEquip) {
			Rect slotRect = new Rect(200, 30, 80, 25);
			int str = (EquipStats())[0];
			int defence = (EquipStats())[1];
			GUI.Box ((slotRect), "Weapon: " + str);
			GUI.Box ((new Rect(200, 60, 80, 25)), "Defence: " + defence);
		}
	
		
	}
	//Responsible for drawing the inventory 
	void DrawInventory(){
		//variable for current Event just so its easier to type
		Event currentEvent = Event.current;
		int i = 0;
		for(int y = 0; y < slotsY; y++){
			for(int x = 0; x < slotsX; x++)
			{	//will apply gui skin throughout inventory 
				Rect slotRect = new Rect(x*30, y*30, 30, 25);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				//If slot[i] contains an item, draw the texture
				if(slots[i].itemName != null){
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					//If mouse is over slotRect that has an item
					if(slotRect.Contains(currentEvent.mousePosition)){
						tooltip = CreateTooltip (slots[i]);
						showToolTip = true;
						if(Input.GetButtonDown("Delete")){
							draggedItem = null;
							draggingItem = false;
							inventory[i] = new Item();
						}
						//*******************************************************************************//
						if(currentEvent.button == 1){
							if(currentEvent.type == EventType.mouseUp ){
							Equip (i);
							}
						}

						//Need to check if left clicked on item, then if mouse has been dragged
						if(currentEvent.button == 0 && currentEvent.type == EventType.mouseDrag && !draggingItem){
							//we are dragging an item
							draggingItem = true;
							previousIndex = i;
							//dragged item is equal to what we are now dragging
							draggedItem = slots[i];
							//Empty that inventory slot "so it does not look like cloning"
							inventory[i] = new Item();
						}
						//Since we know the position will contain an item, will swap the indexed of the items in the Inventory 
						if(currentEvent.type == EventType.mouseUp && draggingItem){
							inventory[previousIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
				
					}
				} else {
					//We know this will not swap since mouse is over empty slot
					if(slotRect.Contains(currentEvent.mousePosition)){
						if(currentEvent.type == EventType.mouseUp && draggingItem){
							inventory[i] = draggedItem;
							draggingItem = false; 
							draggedItem = null;
						}
					}
				 }

				if(tooltip == ""){
					showToolTip = false;
				}
			    i++;
				}
			}
	}

	//Will show the description and name of the item 
	string CreateTooltip(Item item){
		tooltip = "<color=#4DA4BF>" + item.itemName + "</color>\n\n" + item.itemDesc;
		return tooltip;
	}
	//Will add an item based on ID 
	public void AddItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemName == null){
				for(int j = 0; j < database.items.Count; j++){
					if(database.items[j].itemID == id){
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}
	//Will remove an item based on ID
	void RemoveItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemID == id){
				inventory[i] = new Item();
				break;
			}
		}
	}
	//Will check if Inventory contains a specific ID
	//make sure to start at 1 on ID for items, 0 will be null 
	bool InventoryContains(int id){
		bool result = false; 
		for (int i = 0; i < inventory.Count; i++) {
			result = inventory[i].itemID == id;
			if(result){
				break;
			}
		}
		return result; 
	}

	void Equip(int index){
		//three cases, one for consumable, one for weapon, and one for armour
		Item temp = inventory[index];
		if (temp.itemType == Item.ItemType.Weapon) {
				inventory[index] = equipment[0];
				equipment[0] = temp;
		} else if (temp.itemType == Item.ItemType.Armour) {
			inventory[index] = equipment[1];
			equipment[1] = temp;
		} else {
			print ("potion");
		}
		print ("equipped");
	}

	public List<int> EquipStats(){
		List<int> stats = new List<int>(); 
		stats.Add (0);
		stats.Add (0);
		stats.Add (0);
		//will be added in order; str, int, def.
		if ((equipment [0] != null && equipment [1] != null)) {
			stats [0] = equipment [0].itemPower + equipment [1].itemPower;
			stats [1] = equipment [0].itemInt + equipment [1].itemInt;
			stats [2] = equipment [0].itemDef + equipment [1].itemDef;
		} else if (equipment [1] != null) {
			stats [0] = equipment [1].itemPower;
			stats [1] = equipment [1].itemInt;
			stats [2] = equipment [1].itemDef;
		} else if (equipment [0] != null) {
			stats [0] = equipment [0].itemPower;
			stats [1] = equipment [0].itemInt;
			stats [2] = equipment [0].itemDef;
		} 
		return stats;
	}
}
