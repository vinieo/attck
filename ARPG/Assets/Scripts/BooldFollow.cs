using UnityEngine;
using System.Collections;
using UnityEngine.UI;//要使用UI控件，必须引入这个命名空间
/// <summary>
/// 实现敌人血条的跟随及敌人血量的观察
/// </summary>
public class BooldFollow : MonoBehaviour {
	//血条出来，它肯定要知道，是谁创建的它
	private Transform followTarget;

	public Slider hpSlider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//当跟随目标确定后，我们可以实时跟随目标的位置
		if(followTarget!=null){
			//血条的坐标系为屏幕坐标。目标（敌人）的坐标系为世界坐标
			//为了实现跟随，就需要将目标的坐标系转换为屏幕坐标系
			//如何去转：访问到主摄像机，通过主摄像机里面方法
			transform.position=Camera.main.WorldToScreenPoint(followTarget.position);
		}
	}

	public void SetFollowTarget(Transform target){
		//Debug.Log ("xxxx");
		followTarget = target;
	}
	/// <summary>
	/// 设置血条更新：需要两个参数，一个为跟随目标的当前血量，一个为跟随目标的总血量
	/// 这个方法它更新谁的值？slider的value。需要持有slider
	/// </summary>
	public void SetBoold(int hp,int totalHp){
		hpSlider.value = hp / (float)totalHp;
	}
}
