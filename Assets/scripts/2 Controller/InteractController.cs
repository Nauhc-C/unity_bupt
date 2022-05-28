using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///
public class InteractController : MonoBehaviour
{
    //定义各种文本的gameobject
    public GameObject text2; //NPC
    public GameObject text4; //门
    public GameObject mapimage;//地图
    public GameObject talk;  //说话
    public PlayerInput pi; //获取输入
    private Animator anim;  //获取动画
    //以下是标志符号
    public bool NPC = false;
    public bool door = false;
    public bool cooker = false;
    public bool map = false;
    private bool meetTheDistance = false;

    // Start is called before the first frame update
    void Awake()
    {
        //在唤醒阶段获取各个文本并隐藏
        pi = GetComponent<PlayerInput>();
        text2.SetActive(false);
        text4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //不要先看这里的代码，首先在enter和exit力运行后才在这里运行
        if (pi.react && meetTheDistance && NPC)
        {
            anim.SetTrigger("touch");
            text2.SetActive(false);
            talk.SetActive(true);
            pi.react = false;
            print("摸摸头");
        }
        else if (pi.react && meetTheDistance && door)
        {
            print("加载大世界");
            mapimage.SetActive(true);
            pi.react = false;
        }
    }
    //这个other就是和你发生交互的物体，只能在Ontrigger里面来使用
    private void OnTriggerEnter(Collider other)
    {
        //检测到东西就给一个到达距离内
        meetTheDistance = true;
        //然后判断是什么东西
        if(other.tag == "NPC")
        {
            print("我看到一个人");
            anim = other.GetComponent<Animator>();
            text2.SetActive(true);
            NPC = true;
        }
        else if(other.tag == "door")
        {
            door = true;
            text4.SetActive(true);
            print("我看到大门");
        }




    }
    //注意尽量不要使用OntriggerStay，这个东西很不灵敏
    private void OnTriggerExit(Collider other)
    { 
        if(other.tag == "pickup" || other.tag=="NPC" || other.tag == "chest" || other.tag == "warehouse" || 
            other.tag == "door"||other.tag == "cooker")
        {
            text2.SetActive(false);
            text4.SetActive(false);
            meetTheDistance = false;
            NPC = false;
            door = false;
        }
        
    }
}
