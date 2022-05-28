using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///!注意不同脚本间的传参数方式
///这里是所有动的核心，人物移动的控制器
public class ActorController : MonoBehaviour
{
    //定义了模型，输入脚本和动画控制器
    public GameObject model;
    public PlayerInput pi;
    private Animator anim;
    //定义刚体，注意刚体不要update里调用，要在fixedupdate的
    public Rigidbody rigid;
    //定义移动方向和跳跃的冲量
    private Vector3 planerVec;
    private Vector3 thrustVec;
    //定义走路速度和跑步速度和跳跃高度
    public float speed = 1.0f;
    public float runspeed = 2.0f; //这里代表的是倍数哦
    public float jumphigh = 6.0f;
    private bool lockPlaner=false;
    // Start is called before the first frame update
    void Awake()
    {
        //初始化输入模块和动画控制器
        pi = GetComponent<PlayerInput>();
        anim = model.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //这里Mathf.Sqrt((pi.Dup * pi.Dup) + (pi.Dright*pi.Dright))算出DupDright距离原点的距离来设置速度
        anim.SetFloat("speed", pi.Dmag * Mathf.Lerp(anim.GetFloat("speed"), ((pi.run) ? 2.0f : 1.0f), 0.5f));
        if (pi.jump)
        {
            anim.SetTrigger("jump");
        }
        
        //这里设置模型的方向
        if (pi.Dmag > 0.1f)  //在完全松手的时候就不旋转了
        {
            //这一句让转身更加顺滑，注意Vector3.slerp的用法？？
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.02f);
        }
        //这一句是不锁定输入时后的计算速度的方法
        if (lockPlaner == false)
        {
            planerVec = pi.Dmag * model.transform.forward * speed * ((pi.run) ? runspeed : 1.0f);
        }


    }
    //注意要使用time.fixeddelattime
    private void FixedUpdate()
    {
        //rigid.position += planerVec * Time.fixedDeltaTime;
        rigid.velocity = new Vector3(planerVec.x, rigid.velocity.y, planerVec.z) + thrustVec;
        thrustVec = Vector3.zero;
    }
    /// <summary>
    /// 这里要处理大量的message
    /// </summary>
    public void onJumpEnter()
    {
        pi.inputEnabled = false;
        lockPlaner = true;
        thrustVec = new Vector3(0, jumphigh, 0);
        StartCoroutine("onJumpExit");
    }
    IEnumerator onJumpExit()
    {
        yield return new WaitForSeconds(0.6f);
        pi.inputEnabled = true;
        lockPlaner = false;
    }
}
