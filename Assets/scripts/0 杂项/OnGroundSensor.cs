using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///sensor�Ǵ���������˼������ű���������ǲ����ڵ���
public class OnGroundSensor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Untagged")
        {
            print("���");
            SendMessageUpwards("IsGround");
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Untagged")
        {
            SendMessageUpwards("IsGround");
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Untagged")
        {
            print("���");
            SendMessageUpwards("IsNotGround");
        }
            
    }
}
