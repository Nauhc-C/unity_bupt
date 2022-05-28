using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///!ע�ⲻͬ�ű���Ĵ�������ʽ
///���������ж��ĺ��ģ������ƶ��Ŀ�����
public class ActorController : MonoBehaviour
{
    //������ģ�ͣ�����ű��Ͷ���������
    public GameObject model;
    public PlayerInput pi;
    private Animator anim;
    //������壬ע����岻Ҫupdate����ã�Ҫ��fixedupdate��
    public Rigidbody rigid;
    //�����ƶ��������Ծ�ĳ���
    private Vector3 planerVec;
    private Vector3 thrustVec;
    //������·�ٶȺ��ܲ��ٶȺ���Ծ�߶�
    public float speed = 1.0f;
    public float runspeed = 2.0f; //���������Ǳ���Ŷ
    public float jumphigh = 6.0f;
    private bool lockPlaner=false;
    // Start is called before the first frame update
    void Awake()
    {
        //��ʼ������ģ��Ͷ���������
        pi = GetComponent<PlayerInput>();
        anim = model.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //����Mathf.Sqrt((pi.Dup * pi.Dup) + (pi.Dright*pi.Dright))���DupDright����ԭ��ľ����������ٶ�
        anim.SetFloat("speed", pi.Dmag * Mathf.Lerp(anim.GetFloat("speed"), ((pi.run) ? 2.0f : 1.0f), 0.5f));
        if (pi.jump)
        {
            anim.SetTrigger("jump");
        }
        
        //��������ģ�͵ķ���
        if (pi.Dmag > 0.1f)  //����ȫ���ֵ�ʱ��Ͳ���ת��
        {
            //��һ����ת�����˳����ע��Vector3.slerp���÷�����
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.02f);
        }
        //��һ���ǲ���������ʱ��ļ����ٶȵķ���
        if (lockPlaner == false)
        {
            planerVec = pi.Dmag * model.transform.forward * speed * ((pi.run) ? runspeed : 1.0f);
        }


    }
    //ע��Ҫʹ��time.fixeddelattime
    private void FixedUpdate()
    {
        //rigid.position += planerVec * Time.fixedDeltaTime;
        rigid.velocity = new Vector3(planerVec.x, rigid.velocity.y, planerVec.z) + thrustVec;
        thrustVec = Vector3.zero;
    }
    /// <summary>
    /// ����Ҫ���������message
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
