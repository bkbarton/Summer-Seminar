using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public  class LastFloor : MonoBehaviour{
	private bool showText;
	
	void Start(){
		showText = true;
	}
	void Update(){
		if (Input.anyKey) {
			showText = false;
		}
	}
	void OnGUI(){
		
		if (showText) {
			Rect textRect = new Rect (550, 250, 300, 100);
			GUI.Box (textRect, "Woah what is this place\n Looks like some type of den\n I need to get out of here fast");
			
		}
	}
}