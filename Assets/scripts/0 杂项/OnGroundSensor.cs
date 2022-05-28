using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///sensor是传感器的意思，这个脚本用来检测是不是在地面
public class OnGroundSensor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Untagged")
        {
            print("落地");
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
            print("起飞");
            SendMessageUpwards("IsNotGround");
        }
            
    }
}
