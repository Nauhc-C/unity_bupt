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
    public GameObject text4; //箱子
    public GameObject text5; //放下箱子
    //public GameObject mapimage;//地图
    public GameObject talk;  //说话
    //public PlayerInput pi; //获取输入
    private Animator anim;  //获取动画
    //以下是标志符号
    public bool NPC = false;
    public bool box = false;
    public bool release = false;
    public bool map = false;
    private bool meetTheDistance = false;

    // Start is called before the first frame update
    public GameObject boxGO;
    public GameObject boxReal;
    public GameObject NPCTemp;
    public bool flag = true;
    void Awake()
    {
        //在唤醒阶段获取各个文本并隐藏
        //pi = GetComponent<PlayerInput>();
        text2.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //不要先看这里的代码，首先在enter和exit力运行后才在这里运行
        if (Input.GetKeyDown(KeyCode.F) && meetTheDistance && NPC)
        {

            //anim.SetTrigger("touch");

            text2.SetActive(false);
            talk.GetComponent<DialogSystem>().D_NPCTemp = NPCTemp;
            talk.GetComponent<DialogSystem>().textfile = NPCTemp.GetComponent<NPC>().textfile[NPCTemp.GetComponent<NPC>().n];
            if (flag)
            {
                talk.GetComponent<DialogSystem>().manualAwake();
                flag = false;
            }
            talk.SetActive(true);
            
            //NPCTemp.GetComponent<NPC>().n++;
            //pi.react = false;
            print("摸摸头");
        }
        else if (Input.GetKeyDown(KeyCode.F) && meetTheDistance && box)
        {
            boxGO.SetActive(false);
            text4.SetActive(false);
            boxReal.SetActive(true);
            //mapimage.SetActive(true);
            //pi.react = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && meetTheDistance && release)
        {
            text5.SetActive(false);
            boxReal.SetActive(false);
            boxGO.SetActive(true);
            boxGO.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-0.5f, this.transform.position.z)            ;
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
            NPCTemp = other.gameObject;
        }
        else if(other.tag == "box")
        {
            box = true;
            text4.SetActive(true);
            print("我看到箱子");
            boxGO = other.gameObject;
        }
        else if (other.tag == "coin")
        {
            print("捡到金币");
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "release")
        {
            release = true;
            print("到达区域");
            text5.SetActive(true);
        }




    }
    //注意尽量不要使用OntriggerStay，这个东西很不灵敏
    private void OnTriggerExit(Collider other)
    { 
        if(other.tag == "pickup" || other.tag=="NPC" || other.tag == "chest" || other.tag == "warehouse" || 
            other.tag == "box"||other.tag == "release")
        {
            text2.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            meetTheDistance = false;
            NPC = false;
            box = false;
            flag = true;
        }
        
    }
}
