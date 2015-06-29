using UnityEngine;
using System.Collections;

public class Down_Floor : MonoBehaviour {
	static public bool			floorNext = false;

	void OnTriggerEnter2D(Collider2D co){
		floorNext = true;
	}
}
