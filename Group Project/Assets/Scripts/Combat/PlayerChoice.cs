using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerChoice : MonoBehaviour {
    public static PlayerChoice S; //singleton
	public Inventory inv;
    public int weaponDmg = 5; //amount of damage the current weapon deals
    public int Maxhealth = 50; //ammount of damage the player can take before losing
	public int defence = 1;
    public int damageDealt = 0; //amount of damage the player's attack is about to deal
	public int currHealth = 50;
    public bool hit = false;
	private int att;
	private int def;
	private int batt = 5;
	private int prevDef = 1;
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
		if(prevDef != (inv.EquipStats())[2]){
			prevDef = def;
			def = (inv.EquipStats())[2];
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
