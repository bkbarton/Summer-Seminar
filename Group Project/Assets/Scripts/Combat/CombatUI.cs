using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour {
    public static CombatUI S; //singleton

    public GameObject ui; //the combat ui
    public bool __________________________;
    public bool isShowing = false; //whether or not the ui is showing

	// Use this for initialization
	void Start () {
        S = this;
        //sets the combat UI to not show when the game begins
        ui.SetActive(isShowing);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void showUI()
    {
        //shows the combat UI if it is hidden or hides the combat UI if it is being shown when this method is called
        ui.SetActive(isShowing);
        
    }

}
