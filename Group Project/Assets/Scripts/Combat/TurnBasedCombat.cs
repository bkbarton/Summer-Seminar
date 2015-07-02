using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    public Camera cam1; //MainCamera
    public Camera cam2; //CombatCamera
    public GameObject[] prefabEnemies; //collection of all the enemies to draw from

	// Use this for initialization
	void Start () {
        S = this;
        currentState = CombatStates.NOTHING; //player is not in combat as soon as the game begins

        //main camera is turned on, combat camera is kept off
        cam1.enabled = true;
        cam2.enabled = false;
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
                //print("Combat!");
                if (cam2.enabled == false)
                {
                    //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false; would disable player movement while combat is going on but results in some janky movements bugs
                    cam1.enabled = false;
                    cam2.enabled = true;
                    Spawn();
                    CombatUI.S.isShowing = true;
                    CombatUI.S.showUI();
                    currentState = CombatStates.PLAYER;
                }
                break;
            case(CombatStates.PLAYER):
                //player's turn
                if (PlayerChoice.S.health <= 0)
                {
                    currentState = CombatStates.LOSE;
                }
                break;
            case(CombatStates.ENEMY):
                //enemy's turn
                
                break;
            case(CombatStates.WIN):
                //winning condition
                cam1.enabled = true;
                cam2.enabled = false;
                CombatUI.S.isShowing = false;
                CombatUI.S.showUI();
                //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
                break;
            case(CombatStates.RUN):
                //Player flees from combat
                //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
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

    void Spawn()
    {
        int index = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[index] as GameObject);
        go.transform.Translate(GameObject.Find("EnemySpawner").transform.position);
    }

}
