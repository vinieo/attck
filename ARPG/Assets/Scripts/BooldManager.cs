using UnityEngine;
using System.Collections;
/// <summary>
///提供创建血条的方法，作为血条管理的中间类 
/// </summary>
public class BooldManager : MonoBehaviour {
	public static BooldManager instance;//定义一个单例，让外界更容易访问到这个脚本

	//由于要创建血条，所以需要持有血条的预置
	public GameObject booldBar;
	// 这是脚本中最先执行的方法
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	///创建血条
	/// </summary>
	public BooldFollow CreateBooldBar(Transform target){
		//执行血条的实例化
		GameObject go=Instantiate (booldBar)as GameObject;
		//设置父级
		go.transform.parent = this.transform;
		//设置局部坐标为原点
		go.transform.localPosition = Vector3.zero;
		//到这里面我们需要解决两个问题：1、是由谁创建的这个血条，2、血条出来该跟着谁
		//血条创建后，我们可以通过传递target传到血条身上
		BooldFollow boold= go.GetComponent<BooldFollow> ();

		boold.SetFollowTarget (target);

		return boold;

	}
}
