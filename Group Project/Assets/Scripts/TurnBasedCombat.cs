using UnityEngine;
using System.Collections;

public enum CombatStates
{
    NOTHING,
    START,
    PLAYER,
    ENEMY,
    WIN,
    RUN,
    LOSE
}
public class TurnBasedCombat : MonoBehaviour {
    static public TurnBasedCombat S; //singleton

    //the different states there are for combat
    //player is the player's turn and enemy is the enemy's turn
    //bottom three are exit conditions
    

    public CombatStates currentState;

	// Use this for initialization
	void Start () {
        S = this;
        currentState = CombatStates.NOTHING;
        print("start test");
        
	}
	
	// Update is called once per frame
	void Update () {
        //state machine that will do different things depending on what is going on
        //start will initialize combat and bring up the combat overlay
        //player's turn will offer the player a few decisions
        //enemy's turn will do different things based on the enemy
        switch (currentState)
        {
            case(CombatStates.START):
                //starting combat
                print("Combat!");
                break;
            case(CombatStates.PLAYER):
                //player's turn
                break;
            case(CombatStates.ENEMY):
                //enemy's turn
                break;
            case(CombatStates.WIN):
                //winning condition
                break;
            case(CombatStates.RUN):
                //Player flees from combat
                break;
            case(CombatStates.LOSE):
                //losing condition
                break;
        }
	}

    //sets the combat state to whatever is given
    public void SetState(CombatStates cstate)
    {
        currentState = cstate;
    }

}
