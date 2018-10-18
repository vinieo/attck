using UnityEngine;
using System.Collections;
/// <summary>
///控制角色移动 
/// </summary>
public class PlayerMove : MonoBehaviour {
	//通过钢体控制移动，需要定义一个钢体变量
	private Rigidbody rb;
	//由于移过程中需要播放动画
	private Animator anim;

	public float moveSpeed=3;
	// Use this for initialization
	void Start () {
		//得到钢体组件与动画组件
		rb = GetComponent<Rigidbody> ();
		anim=GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	   //Input.GetKey:获得键盘按键
		//Input.GetMouseButton:获得鼠标按键
		//Input.GetAxis ();获得坐标轴的输入。返回的float：-1到1之间的值
		float h=Input.GetAxis("Horizontal");//获得水平轴按键的按下，它代表的按键为：AD和左右方向
		float v=Input.GetAxis ("Vertical");//代表WS或者上下方向
		if(Joystick.x!=0||Joystick.y!=0){
			h=Joystick.x;
			v=Joystick.y;
		}

		Vector3 dir = new Vector3 (h,0,v);
		if (h != 0 || v != 0) {//表示wasd这几个按键有一个被按下
			anim.SetBool ("Run", true);
			//rb.MovePosition(当前位置+移动方向*速度)
			//当前位置：transform.position
			//移动方向：首先它是一个三维向量，而且是通过我们按键来判断
			rb.MovePosition(transform.position+dir*Time.deltaTime*moveSpeed);
			//控制玩家按按键执行旋转
			transform.rotation=Quaternion.LookRotation(dir,transform.up);
		} else {
			anim.SetBool("Run",false);
		}
		//当按下某个按键的时候，执行攻击动作
		if(Input.GetKeyDown(KeyCode.H)){
			anim.SetTrigger("Attack1");
		}
		if(Input.GetKeyDown(KeyCode.J)){
			anim.SetTrigger("Attack2");
		}
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Attack3");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetTrigger("Attack4");
        }


    }
	public void PlayAttack( int index){
		anim.SetTrigger("Attack"+index);
	}
}
