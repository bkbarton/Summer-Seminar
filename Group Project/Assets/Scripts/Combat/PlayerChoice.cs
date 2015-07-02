using UnityEngine;
using System.Collections;

public class PlayerChoice : MonoBehaviour {
    public static PlayerChoice S; //singleton
    
    public int weaponDmg = 5; //amount of damage the current weapon deals
    public int health = 100; //ammount of damage the player can take before losing
    public int damageDealt = 0; //amount of damage the player's attack is about to deal
    public bool hit = false;

	// Use this for initialization
	void Start () {
        S = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attack()
    {
        damageDealt = weaponDmg;
        hit = true;
        print("attack!");
    }
}
