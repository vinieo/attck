using UnityEngine;
using System.Collections;
/// <summary>
/// 敌人的AI行为
/// </summary>
public class Enemy : MonoBehaviour {
	private Rigidbody rb;
	private Animator anim;

	//由于要计算与玩家之间的距离，需要得到玩家
	private Transform player;

	public float dis=0;
	public float attackDis=3;
	public float moveSpeed=3;

	public float totalTime=3;//攻击总时间
	private float timer=0;
	//持有寻路的路径
	private Transform[] paths;
	//在数组出现的地方，一般会出现下标和for循环
	//数组的下标从0开始，数组长度减1结束
	private int index=0;
	//敌人的旋转速度：值越大，旋转得越快
	public float rotateSpeed=3;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
		anim=GetComponent<Animator>();
		//GameObject.FindGameObjectWithTag ("物体的标签"):通过标签查找游戏物体
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//通过查找游戏物体的方式 得到路径
		paths=GameObject.Find("Paths").GetComponent<Paths>().paths;
	
	}
	
	// Update is called once per frame
	void Update () {
		//计算与玩家之间的距离:通过Vector3.Distance(点1，点2)
		dis = Vector3.Distance (transform.position,player.position);

		//根据计算出来的距离来判断敌人的行为
		//当距离大于8，敌人执行寻路行为
		//当距离小于等8，前大于3，敌人执行追击行为
		//小于等于3，待机并执行攻击
		if (dis > 8) {
			anim.SetBool("WTOR",false);//从跑步状态切换到寻路状态
			moveSpeed=2f;
			Vector3 pos=paths[index].position;
			pos.y=transform.position.y;
			//得到移动方向
			Vector3 dir=pos-transform.position;
			rb.MovePosition(transform.position+dir.normalized*Time.deltaTime*moveSpeed);
			//处理旋转
			//选持有目标旋转，再通过旋转插值的方式进行平滑旋转
			Quaternion look=Quaternion.LookRotation(dir,transform.up);
			//Quaternion.Lerp（当前旋转，目标旋转，旋转速度）：旋转插值
			transform.rotation=Quaternion.Lerp(transform.rotation,look,rotateSpeed*Time.deltaTime);

			//还应判断，敌人与路径点的距离如果小于一定值
			//当到达目标点的时候
			if(Vector3.Distance(pos,transform.position)<1f){
//				index++;
//				//当自增完成后，索引的值超出数组的话
//				index%=paths.Length;
				//随机寻路路径点
				index=Random.Range(0,paths.Length);
			}


		} else if (dis <=8 && dis > attackDis) {//追击行为
			moveSpeed=3;
			//播放跑步动画，执行移动，执行朝向
			anim.SetBool("WTOR",true);//从寻路状态切换追击状态
			anim.SetBool("RTOI",false);//从待机状态到追击状态
			//要得到敌人到玩家的方向，：玩家的位置-敌人的位置
			//由于向量有方向也有距离，那么就需将这个方向的距离保持不变
			//dir.normalized：方向不变，长度为1.单位化向量
			Vector3 dir=player.position-transform.position;
			rb.MovePosition(transform.position+dir.normalized*Time.deltaTime*moveSpeed);
			transform.rotation=Quaternion.LookRotation(dir,transform.up);
		} else {
			//待机并攻击行为
			anim.SetBool("RTOI",true);
			//计时器制作
			timer+=Time.deltaTime;//开始计时
			//transform.lookat();
			transform.LookAt(player);
			if(timer>=totalTime){
				int index=Random.Range(1,3);//Random.Range:随机一个数出来，整数随机不包括最大值
				//数字和字符串相加，得到的就是一个字符串
				anim.SetTrigger("Attack"+index);
				timer=0;
			}

		}
	}
}
