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
        //��ȡplayerinput�ű�
        pi = player.GetComponent<PlayerInput>();
    }
    private void Update()
    {
        //�ڻ�ȡ������ʱ����ʱ��
        if (pi.ESC)
        {
            Time.timeScale = bulletTimeScale;

        }
    }
}
