using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public  class Introduction : MonoBehaviour{
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
			GUI.Box (textRect, "Where am I?\n Am I dreaming?\n No..I need to get out of here\n Seems like the only way to go is down");
	
		}
	}
}

