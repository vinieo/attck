using UnityEngine;
using System.Collections;
/// <summary>
/// 跟随玩家
/// </summary>
public class FollowPlayer : MonoBehaviour {
	//由于要跟随玩家，所以需要得到玩家位置
	private Transform player;
	//需要计算出玩家与摄像之间的偏移
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - player.position;//计算与玩家的偏移
	}
	
	// Update is called once per frame
	void LateUpdate () {//之后更新，它执行于Update之后
		transform.position = player.position + offset;
	}
}
