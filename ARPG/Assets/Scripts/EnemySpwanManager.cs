using UnityEngine;
using System.Collections;
/// <summary>
///控制敌人出生 
/// </summary>
public class EnemySpwanManager : MonoBehaviour {
	//由于要动态创建敌人，所以需要持有敌人的预置物体
	public GameObject enemyPre;
	//将变量设置为静态的，可以非常方便的通过类名的方式访问
	//因为静态变量它是由系统直接调用
	public static int count=0;
	//敌人是按波出生，需要通过延时操进行一个一个的创建，由于要创建多个，所以需要用循环
	// Use this for initialization
	void Start () {
	//协程方法的调用需要通过:SartCoroutine(协程方法)
//		for (int i = 0; i < 5; i++) {
//			//当调用协程的时候，执行实例化操作
//			//Instantiate（要创建的物体，要创建的位置，是否旋转）
//			Instantiate(enemyPre,transform.position,Quaternion.identity);
//			//yield return new WaitForSeconds(2);
//		}


	StartCoroutine (SpwanEnemy());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//协程的定义：协程必须定义为方法，这个方法的返回值必须为IEnumerator
	//协程方法中必须存至少一个yield return
//	IEnumerator CortineFunc(){
//		//当程序遇到yield return的时候，会将程序挂起
//		//当满足条件的时候，执行后面的代码
//		yield return new WaitForSeconds (2);
//		Debug.Log ("暂停完毕");
//	}

	IEnumerator SpwanEnemy(){

		for (int j = 0; j < 3; j++) {//要出生多少波敌人
			for (int i = 0; i < 5; i++) {//每波敌人出生多少个
				//当调用协程的时候，执行实例化操作
				//Instantiate（要创建的物体，要创建的位置，是否旋转）
				Instantiate(enemyPre,transform.position,Quaternion.identity);
				count++;
				//WaitForSeconds(要暂停的时间)：暂停多少秒
				yield return new WaitForSeconds(2);
			}
			//当每波敌人创建完成时，执行While循环
			while(count>0){
				//暂停一帧
				yield return 0;
			}
			//只有当while循环不满足条件的时候，才能执行到这一步
			yield return new WaitForSeconds(3);
		}

	}
}
