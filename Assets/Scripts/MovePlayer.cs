using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float mouseSpeed = 2;
    public float speed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 20.8f;
    private Vector3 moveDirection;
    private CharacterController chCtrl;

    public GameObject CameraRot;
    private float X = 0;
    private float Y = 0;

    // Start is called before the first frame update
    void Start()
    {
        chCtrl = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (chCtrl.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= (gravity * Time.deltaTime);
        chCtrl.Move(moveDirection * Time.deltaTime);

        Y += Input.GetAxis("Mouse X") * mouseSpeed;
        X += Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.eulerAngles = new Vector3(0, Y, 0);
        CameraRot.transform.eulerAngles = new Vector3(-X, Y, 0);
    }
}
