using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AttackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CombatUI.S.isShowing == true)
        {
            CombatUI.S.ui.GetComponent<Button>().onClick.AddListener(() => { PlayerChoice.S.Attack(); });
        }
	}
}
