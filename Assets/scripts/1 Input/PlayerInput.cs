using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //变量区
    //定义的前后左右对应的键盘上的按钮，这样就允许玩家自定义按键
    [Header("常用操控按键")]
    public string KeyUp = "w";
    public string Keydown = "s";
    public string KeyLeft = "a";
    public string KeyRight = "d";
    //定义跑步的按键
    public string Keyrun = "left shift";
    public bool run;
    //定义跳跃的按键
    public string Keyjump = "space";
    public bool jump;
    private bool lastjump;
    public bool space;
    //定义交互的按键
    public string Keyreact = "f";
    public bool react=false;
    //定义转换视角的按键
    public string KeyJUp = "up";
    public string KeyJDown = "down";
    public string KeyJRight = "right";
    public string KeyJLeft = "left"; 
    //定义暂停的按键
    public string KeyESC = "escape";
    public bool ESC;
    [Header("输出")]
    //定义前后速度和左右速度，保证你同时按住前后可以不动
    public float Dup;
    public float Dright;
    /// <summary>
    /// 这里是右边摇杆的部分
    /// </summary>
    public float Jup;
    public float Jright;
    //这两个一个是速度一个是方向
    public float Dmag;
    public Vector3 Dvec;
    //velocity是速度
    public float targetDup;
    public float targetDright;
    public float velocityDup;
    public float velocityDright;
    //这里用于关闭这个脚本
    public bool inputEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //这里两个是转视角的
        Jup = (Input.GetKey(KeyJUp) ? 1.0f : 0) - (Input.GetKey(KeyJDown) ? 1.0f : 0);
        Jright = (Input.GetKey(KeyJRight) ? 1.0f : 0) - (Input.GetKey(KeyJLeft) ? 1.0f : 0);
        //三元运算符（）？（）：（）
        //input.getKey和input.getKeydown的区别
        //前者可以在你按住的时候也可以获得值，后者只在你按下的一瞬间获得值，之后按住不放就又恢复了
        targetDup = (Input.GetKey(KeyUp)?1.0f:0) - (Input.GetKey(Keydown)?1.0f:0);
        targetDright = (Input.GetKey(KeyRight) ? 1.0f : 0) - (Input.GetKey(KeyLeft) ? 1.0f : 0);
        //关闭脚本
        if(inputEnabled == false)
        {
            targetDup = 0;
            targetDright = 0;
        }

        //Mathf方法下的SmoothDamp（光滑减幅）用来给值一个平滑过渡，而不是突变
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Vector2 tempDAxis = SquareToCircle(new Vector2(Dright, Dup));
        float Dright2 = tempDAxis.x;
        float Dup2 = tempDAxis.y;

        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));   //这里是用勾股定理算距离1的距离
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;

        //获取跑步的按键
        run = Input.GetKey(Keyrun);
        //获取跳跃的按键
        
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
        
        //获取交互的按键
        react = Input.GetKeyDown(Keyreact);
        //获取暂停的按键
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
