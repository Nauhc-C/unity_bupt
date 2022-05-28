using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
public class timeController : MonoBehaviour
{
    public PlayerInput pi;
    public GameObject player;
    [SerializeField, Range(0f,2f)] float bulletTimeScale = 0.1f;
    float defaultFixedDeltaTime;
    public void Awake()
    {
        //获取playerinput脚本
        pi = player.GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //在获取到按键时控制时间
        if (pi.ESC)
        {
            Time.timeScale = bulletTimeScale;

        }
    }
}
