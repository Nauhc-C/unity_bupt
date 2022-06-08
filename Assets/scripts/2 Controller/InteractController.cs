using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///
public class InteractController : MonoBehaviour
{
    //��������ı���gameobject
    public GameObject text2; //NPC
    public GameObject text4; //����
    public GameObject text5; //��������
    //public GameObject mapimage;//��ͼ
    public GameObject talk;  //˵��
    //public PlayerInput pi; //��ȡ����
    private Animator anim;  //��ȡ����
    //�����Ǳ�־����
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
        //�ڻ��ѽ׶λ�ȡ�����ı�������
        //pi = GetComponent<PlayerInput>();
        text2.SetActive(false);
        text4.SetActive(false);
        text5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //��Ҫ�ȿ�����Ĵ��룬������enter��exit�����к������������
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
            print("����ͷ");
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
    //���other���Ǻ��㷢�����������壬ֻ����Ontrigger������ʹ��
    private void OnTriggerEnter(Collider other)
    {
        //��⵽�����͸�һ�����������
        meetTheDistance = true;
        //Ȼ���ж���ʲô����
        if(other.tag == "NPC")
        {
            print("�ҿ���һ����");
            anim = other.GetComponent<Animator>();
            text2.SetActive(true);
            NPC = true;
            NPCTemp = other.gameObject;
        }
        else if(other.tag == "box")
        {
            box = true;
            text4.SetActive(true);
            print("�ҿ�������");
            boxGO = other.gameObject;
        }
        else if (other.tag == "coin")
        {
            print("�񵽽��");
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "release")
        {
            release = true;
            print("��������");
            text5.SetActive(true);
        }




    }
    //ע�⾡����Ҫʹ��OntriggerStay����������ܲ�����
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
