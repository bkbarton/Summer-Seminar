using UnityEngine;
using System.Collections;

public class FloatingCombatText : MonoBehaviour {

    public void OnGUI()
    {
        GUI.Label(new Rect(-18, 243, 100, 20), "Hello World!");
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //go.text = 5;
        
	}
}
