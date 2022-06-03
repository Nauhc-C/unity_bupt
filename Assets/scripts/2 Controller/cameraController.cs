using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
public class cameraController : MonoBehaviour
{
    public GameObject Player;
    public float mouseX, mouseY;
    public float mouseSensitivity;

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Player.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(-mouseY, 0, 0);
    }
}
