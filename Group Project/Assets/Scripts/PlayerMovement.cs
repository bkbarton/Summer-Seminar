using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 0.4f;
    public static bool canRunIntoEnemy = true; //true for testing, normally would start at false 
    public float enemyChance = 50;



	Vector2 dest = Vector2.zero;
	// Use this for initialization
	void Start () {
		dest = transform.position;
	}
	
	
	void FixedUpdate () {
		Vector2 p = Vector2.MoveTowards (transform.position, dest, speed); 
		GetComponent<Rigidbody2D>().MovePosition (p);
		float ind = Random.Range(0,200);

		//movement
        //enemy chance is also tied to movement, as the player moves they have a chance to encounter an enemy
        //the chance is deteremined by enemyChance, if the random number generator gives a number below EnemyChance then an encounter begins

        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
        {
            dest = (Vector2)transform.position + Vector2.up;
            if (ind < enemyChance)
            {
                TurnBasedCombat.S.SetState(CombatStates.START);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
        {
            dest = (Vector2)transform.position + Vector2.right;
            if (ind < enemyChance)
            {
                print(ind);
                TurnBasedCombat.S.SetState(CombatStates.START);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
        { 
            dest = (Vector2)transform.position - Vector2.up;
            if (ind < enemyChance)
            {
                TurnBasedCombat.S.SetState(CombatStates.START);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
        {
            dest = (Vector2)transform.position - Vector2.right;
            if (ind < enemyChance)
            {
                TurnBasedCombat.S.SetState(CombatStates.START);
            }
        }
		
		//Animation
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat ("DirX", dir.x);
		GetComponent<Animator>().SetFloat ("DirY", dir.y);
		
		

	}
	
	bool valid(Vector2 dir){
		//??? not working right
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>()) ;
	}

}
