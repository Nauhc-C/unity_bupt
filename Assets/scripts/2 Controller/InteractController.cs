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
    public GameObject text4; //��
    public GameObject mapimage;//��ͼ
    public GameObject talk;  //˵��
    public PlayerInput pi; //��ȡ����
    private Animator anim;  //��ȡ����
    //�����Ǳ�־����
    public bool NPC = false;
    public bool door = false;
    public bool cooker = false;
    public bool map = false;
    private bool meetTheDistance = false;

    // Start is called before the first frame update
    void Awake()
    {
        //�ڻ��ѽ׶λ�ȡ�����ı�������
        pi = GetComponent<PlayerInput>();
        text2.SetActive(false);
        text4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //��Ҫ�ȿ�����Ĵ��룬������enter��exit�����к������������
        if (pi.react && meetTheDistance && NPC)
        {
            anim.SetTrigger("touch");
            text2.SetActive(false);
            talk.SetActive(true);
            pi.react = false;
            print("����ͷ");
        }
        else if (pi.react && meetTheDistance && door)
        {
            print("���ش�����");
            mapimage.SetActive(true);
            pi.react = false;
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
        }
        else if(other.tag == "door")
        {
            door = true;
            text4.SetActive(true);
            print("�ҿ�������");
        }




    }
    //ע�⾡����Ҫʹ��OntriggerStay����������ܲ�����
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
