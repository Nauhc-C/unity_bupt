using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
public class cameraController : MonoBehaviour
{
    public PlayerInput pi;
    public GameObject playerHandle;
    public GameObject cameraHandle;
    public float tempEulerX;

    // 所有的get都应该在Awake阶段
    void Awake()
    {
        cameraHandle = transform.parent.gameObject;
        playerHandle = cameraHandle.transform.parent.gameObject;
        pi = playerHandle.GetComponent<PlayerInput>();
        tempEulerX = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerHandle.transform.Rotate(Vector3.up,pi.Jright * 100.0f * Time.deltaTime);
        tempEulerX -= pi.Jup * -80.0f * Time.deltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -40, 30);
        cameraHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);
    }
}
