using UnityEngine;
using System.Collections;
/// <summary>
/// 实现敌人的伤害与死亡
/// </summary>
public class EnemyHit : MonoBehaviour {
	public int hp=100;//定义敌人的血量
	private int totalHp=0;
	private Animator anim;
	private bool isDeath=false;
	public Transform booldTarget;

	private BooldFollow bf;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
		totalHp = hp;
		bf=BooldManager.instance.CreateBooldBar (booldTarget);
	}
	
	// Update is called once per frame
	void Update () {
		if(isDeath){//如果isDeath为true，代表敌人死透了
			//向下移动：transform.up:代表向上轴向，即：x0,y1,z0
			transform.position-=transform.up*Time.deltaTime*0.8f;
			//判断Y轴的值是否为-1.5，代表已经下落到地下，销毁敌人
			if(transform.position.y<-1.5f){
				Destroy(this.gameObject);
			}

		}
	}
	/// <summary>
	/// 敌人的伤害方法
	/// </summary>
	/// <param name="damage">伤害值</param>
	public void Hit(int damage){
		if(hp>0){//如果血量大于0
			hp-=damage;//执行血量的减少
			anim.SetTrigger("Hit");
			bf.SetBoold(hp,totalHp);
			//当血量减完后，判断敌人的血量是否小于等于零
			if(hp<=0){//条件满足，代表敌人已经死亡
				anim.SetTrigger("Death");
				//当敌人死亡后，需要禁用掉它的行为脚本：组件.enabled=false
				GetComponent<Enemy>().enabled=false;
				//还需要移除钢体和碰撞体。移除组件：Destroy(组件名字)
				Rigidbody rb=GetComponent<Rigidbody>();//得到钢体
				Destroy(rb);//销毁钢体
				Collider c=GetComponent<Collider>();
				Destroy(c);
				//当敌人死亡的时候，删除血条
				Destroy(bf.gameObject);
				Invoke("DestroyEnemy",3);
			}
		}
	}
	/// <summary>
	/// 销毁敌人
	/// </summary>
	void DestroyEnemy(){
		//Destroy (this.gameObject);
		isDeath = true;
		EnemySpwanManager.count--;
	}
}
