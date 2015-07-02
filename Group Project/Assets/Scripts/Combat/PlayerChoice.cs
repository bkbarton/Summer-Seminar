using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerChoice : MonoBehaviour {
    public static PlayerChoice S; //singleton
	public Inventory inv;
    public int weaponDmg = 5; //amount of damage the current weapon deals
    public int health = 30; //ammount of damage the player can take before losing
    public int damageDealt = 0; //amount of damage the player's attack is about to deal
    public bool hit = false;
	private int att;
	private int def;
	private int batt = 5;
	private int bHealth = 30;
	// Use this for initialization
	void Start () {
        S = this;
	}

	// Update is called once per frame
	void Update () {
		inv = GetComponentInChildren<Inventory> () as Inventory;
		 att = (inv.EquipStats ()) [0];
		if(batt != (weaponDmg - att)){
			weaponDmg += att;
		}
		 def = (inv.EquipStats ()) [2];
		if(bHealth != (health - def)){
	    	 health += def;
		}
	}

    public void Attack()
    {

        damageDealt = weaponDmg;
        hit = true;
        print("attack!");
        TurnBasedCombat.S.currentState = CombatStates.ENEMY;
    }
}
