using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///
public class DialogSystem : MonoBehaviour
{
    [Header("UI���")]
    //�����ı���ͼ��
    public Text textLabel;
    //public Image faceImage;
    public float �ַ��ٶ�=0.1f;

    [Header("�ı��ļ�")]
    //����
    public TextAsset textfile;
    public int index;
    public bool textfinish;
    [Header("ͷ��")]
    public Sprite face01, face02;

    public GameObject D_NPCTemp;

    //�������ֵ��б�
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    private void Awake()
    {
        GetTextFromFile(textfile);
    }

    public void manualAwake()
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
            D_NPCTemp.GetComponent<NPC>().n++;
            if(D_NPCTemp.GetComponent<NPC>().n >= D_NPCTemp.GetComponent<NPC>().textfile.Length)
            {
                D_NPCTemp.GetComponent<NPC>().n = D_NPCTemp.GetComponent<NPC>().textfile.Length-1;
            }
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
        //���ı��������и�
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
        print("ǰ���ִ����");

        switch(textList[index].Trim().ToString())
        {
            case "A":
                print("ִ����");
                //faceImage.sprite = face01;
                index++;
                break;
            case "B":
                //faceImage.sprite = face02;
                index++;
                break;
        }
        print("�����ִ����");
        if(textList[index].Trim().ToString() == "��ͬѧ�G,�ǰ��Ұ���֮��,�Ҵ����һ��ѧУ��")
        {
            print("surprise");
        }
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(�ַ��ٶ�);
        }
        textfinish = true;
        index++;
        
    }

}
