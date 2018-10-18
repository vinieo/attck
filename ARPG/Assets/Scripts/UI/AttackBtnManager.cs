using UnityEngine;
using System.Collections;

public class AttackBtnManager : MonoBehaviour {
	private PlayerMove pm;
	// Use this for initialization
	void Start () {
		pm = GameObject.Find("Player").GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AttackBtnClick(int index){
		pm.PlayAttack (index);
	}
}
