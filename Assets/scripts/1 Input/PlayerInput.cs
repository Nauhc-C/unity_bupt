using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //������
    //�����ǰ�����Ҷ�Ӧ�ļ����ϵİ�ť����������������Զ��尴��
    [Header("���òٿذ���")]
    public string KeyUp = "w";
    public string Keydown = "s";
    public string KeyLeft = "a";
    public string KeyRight = "d";
    //�����ܲ��İ���
    public string Keyrun = "left shift";
    public bool run;
    //������Ծ�İ���
    public string Keyjump = "space";
    public bool jump;
    private bool lastjump;
    public bool space;
    //���彻���İ���
    public string Keyreact = "f";
    public bool react=false;
    //����ת���ӽǵİ���
    public string KeyJUp = "up";
    public string KeyJDown = "down";
    public string KeyJRight = "right";
    public string KeyJLeft = "left"; 
    //������ͣ�İ���
    public string KeyESC = "escape";
    public bool ESC;
    [Header("���")]
    //����ǰ���ٶȺ������ٶȣ���֤��ͬʱ��סǰ����Բ���
    public float Dup;
    public float Dright;
    /// <summary>
    /// �������ұ�ҡ�˵Ĳ���
    /// </summary>
    public float Jup;
    public float Jright;
    //������һ�����ٶ�һ���Ƿ���
    public float Dmag;
    public Vector3 Dvec;
    //velocity���ٶ�
    public float targetDup;
    public float targetDright;
    public float velocityDup;
    public float velocityDright;
    //�������ڹر�����ű�
    public bool inputEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����������ת�ӽǵ�
        Jup = (Input.GetKey(KeyJUp) ? 1.0f : 0) - (Input.GetKey(KeyJDown) ? 1.0f : 0);
        Jright = (Input.GetKey(KeyJRight) ? 1.0f : 0) - (Input.GetKey(KeyJLeft) ? 1.0f : 0);
        //��Ԫ���������������������
        //input.getKey��input.getKeydown������
        //ǰ�߿������㰴ס��ʱ��Ҳ���Ի��ֵ������ֻ���㰴�µ�һ˲����ֵ��֮��ס���ž��ָֻ���
        targetDup = (Input.GetKey(KeyUp)?1.0f:0) - (Input.GetKey(Keydown)?1.0f:0);
        targetDright = (Input.GetKey(KeyRight) ? 1.0f : 0) - (Input.GetKey(KeyLeft) ? 1.0f : 0);
        //�رսű�
        if(inputEnabled == false)
        {
            targetDup = 0;
            targetDright = 0;
        }

        //Mathf�����µ�SmoothDamp���⻬������������ֵһ��ƽ�����ɣ�������ͻ��
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Vector2 tempDAxis = SquareToCircle(new Vector2(Dright, Dup));
        float Dright2 = tempDAxis.x;
        float Dup2 = tempDAxis.y;

        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));   //�������ù��ɶ��������1�ľ���
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;

        //��ȡ�ܲ��İ���
        run = Input.GetKey(Keyrun);
        //��ȡ��Ծ�İ���
        
        bool newJump = Input.GetKey(Keyjump);
        if (newJump != lastjump && newJump == true)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        lastjump = newJump;
        
        //��ȡ�����İ���
        react = Input.GetKeyDown(Keyreact);
        //��ȡ��ͣ�İ���
        ESC = Input.GetKeyDown(KeyESC);

    }

    private Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = Vector2.zero;
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);
        return output;
    }


}
