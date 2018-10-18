using UnityEngine;
using System.Collections;
using System.Collections.Generic;//泛型所处的命名空间
/// <summary>
/// 控制玩家攻击及伤害
/// </summary>
public class PlayerAttack : MonoBehaviour {
	public float r=3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 添加事件的时候，需要在我们的脚本中添加一个与事件名字相同的方法，否则会报错
	/// </summary>
	void Attack(){
		//本地从标和局部从标
	List<GameObject>	enemyList= GetAttackRangeEnemy ();
		if(enemyList.Count>0){//如果可攻击的敌人数量大于零
			//遍历敌人集合
			for (int i = 0; i < enemyList.Count; i++) {
				//得到第i个敌人身上的伤害脚本
				EnemyHit hit=enemyList[i].GetComponent<EnemyHit>();
				hit.Hit(50);
			}
		}
	}

	/// <summary>
	/// 得到可攻击范围内的敌人：
	/// 1、需要得到敌人集合。需要这个方法有返回值：List<GameObject>
	/// </summary>
	List<GameObject> GetAttackRangeEnemy(){
		List<GameObject> enemyList = new List<GameObject> ();//定义一个用于存储敌人的集合

		//球形检测方法 
		//Physics.OverlapSphere (起点，半径，检测的层级);
		//1<<LayerMask.NameToLayer("Enemy"):表示只检测Enemy这个层
		Collider[] enemys = Physics.OverlapSphere (transform.position,r,1<<LayerMask.NameToLayer("Enemy"));
		//首先判断敌人是否在攻击范围内
		if(enemys.Length>0){
			//如果敌人在攻击范围内，遍历所有的敌人
			for (int i = 0; i < enemys.Length; i++) {
				//ransform.InverseTransformPoint(enemys[i].transform.position);将第i个敌人从世界坐标转换成玩家的局部坐标
				Vector3 pos=transform.InverseTransformPoint(enemys[i].transform.position);
				//如果pos.z大于零。表示敌人在玩家的前面
				if(pos.z>0){
					//将敌人的游戏物体添加可攻击的敌人集合时里面
					enemyList.Add(enemys[i].gameObject);
				}

			}
		}
		return enemyList;
	}
}
