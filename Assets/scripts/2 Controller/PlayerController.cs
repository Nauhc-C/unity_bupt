using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    public float gravity;
    public Vector3 velocity;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius;
    public bool isGround;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("jump");
            velocity.y = jumpSpeed;
        }

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }

}
