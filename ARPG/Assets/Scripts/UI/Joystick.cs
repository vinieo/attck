using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

	public static float x=0;
	public static float y=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnMoveClick(Vector2 dir){
		x = dir.x;
		y = dir.y;
	}
	public void OnMoveEndClick(){
		x = 0;
		y = 0;
	}
}
