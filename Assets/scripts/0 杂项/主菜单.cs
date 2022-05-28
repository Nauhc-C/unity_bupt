using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>
///
public class 主菜单 : MonoBehaviour
{
    public void NewGame()
    {
        //playerPrefs是一种存贮数据的方法，利用键值对的方法
        //这里的DeleteAll()是删除所有的键和值
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");

    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Application.Quit();
        print("退出游戏");
    }
}
