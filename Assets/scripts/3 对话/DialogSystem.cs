using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///
public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    //定义文本和图像
    public Text textLabel;
    public Image faceImage;
    public float 字符速度;

    [Header("文本文件")]
    //定义
    public TextAsset textfile;
    public int index;
    public bool textfinish;
    [Header("头像")]
    public Sprite face01, face02;


    //储存文字的列表
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    private void Awake()
    {
        GetTextFromFile(textfile);
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.F) && textfinish)
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        //把文本按照行切割
        var linedata = file.text.Split('\n');
        foreach (var line in linedata)
        {
            textList.Add(line);
        }

    }

    IEnumerator SetTextUI()
    {
        textfinish = false;
        textLabel.text = "";
        print("前面的执行了");

        switch(textList[index].Trim().ToString())
        {
            case "A":
                print("执行了");
                faceImage.sprite = face01;
                index++;
                break;
            case "B":
                faceImage.sprite = face02;
                index++;
                break;
        }
        print("后面的执行了");
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(字符速度);
        }
        textfinish = true;
        index++;
        
    }

}
