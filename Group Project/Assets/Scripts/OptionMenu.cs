using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionMenu: MonoBehaviour{

	public Canvas	optionsMenu;
	private bool	ui;
	void Start(){
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		ui = false;
		optionsMenu.enabled = ui;
	}
	void Update(){
		if(Input.GetButtonDown ("Options")){
			ui = !ui;
			optionsMenu.enabled = ui;
		}

		//To exit and return to main menu
		if (Input.GetKeyDown ("escape")) {
			Application.LoadLevel(0);
		}

	}
}

