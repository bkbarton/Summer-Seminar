using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    //stats
    public int health = 10;
    public int armor = 1;
    public int exp = 20;
    public int gold = 5;

    void Awake()
    {
    
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            TurnBasedCombat.S.currentState = CombatStates.WIN;
            Destroy(this.gameObject);
        }
        if (PlayerChoice.S.hit == true)
        {
            print(PlayerChoice.S.damageDealt);
            health = health - PlayerChoice.S.damageDealt;
            PlayerChoice.S.hit = false;
        }
	}

}
