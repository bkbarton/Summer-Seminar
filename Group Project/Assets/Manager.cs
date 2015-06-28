using UnityEngine;
using System.Collections;

public enum GameMode{
	idle, 
	playing, 
	levelEnd,
	combat
}
public class Manager : MonoBehaviour {
	static public Manager	S;
	//Fields set in inspector
	public GameObject[]		floors;
	public Vector3			floorPos;//place to put the floor
	//Fields set dynamically
	public bool ___________;
	public int				level;
	public int				levelMax;
	public GameObject		floor;
	public GameMode			mode = GameMode.idle;

	void Start(){
		S = this;
		level = 0;
		levelMax = floors.Length;
		StartLevel ();
	}

	void StartLevel(){
		//Get rid of old stage if one exists
		if (floor != null) {
			Destroy (floor);
		}
		//Instantiate new floor
		floor = Instantiate (floors[level] )as GameObject;
		floor.transform.position = floorPos;
		//Reset floor
		Down_Floor.floorNext = false;
		mode = GameMode.playing;

	}

	void Update(){
		if (mode == GameMode.playing && Down_Floor.floorNext) {
			mode = GameMode.levelEnd;
			Invoke ("NextLevel", 2f);
		}
	}

	void NextLevel(){
		level++;
		if (level == levelMax) {
			level = 0;
		}
		StartLevel ();
	}
}
