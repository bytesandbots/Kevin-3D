using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float rotSpeed = 60;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float runSpeed = 10;

    public Animator anim;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
        Cursor.lockState = CursorLockMode.Locked;
        // let the gameObject fall down
    }

    void Update()
    {
        float oldy = moveDirection.y; 
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection = moveDirection * runSpeed;
        }
        else
        {
            moveDirection = moveDirection * speed;
        }
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes



            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                anim.SetTrigger("jump");
            }
        }

        else {
            moveDirection.y = oldy;
        }
        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);


        float horizontal = Input.GetAxis("Mouse X") * rotSpeed;

        
        transform.Rotate(new Vector3(0, horizontal, 0) * Time.deltaTime);

        Vector3 local = transform.localEulerAngles;
        local.z = 0;
        transform.localEulerAngles = local;
        Vector3 temp = moveDirection;
        temp.y = 0;
        anim.SetFloat("speed", temp.magnitude);

    }
}
