using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 8.0f;
    private float rotationSpeed = 360.0f;
    private float gravity = -2.2f;
    private float yVelocity = 0.0f;
    private float jumpForce = 0.2f;
    public int countJump = 0;
    private CharacterController charController;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
        gravity = jumpForce * -4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player rotation
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        //anim.SetFloat("mouseX", mouseX);
        transform.Rotate(rotation);

        // Handle player movement
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float variance = 0.01f;
        bool isMoving = Mathf.Abs(deltaX) > variance || Mathf.Abs(deltaZ) > variance;
        //anim.SetBool("isMoving", isMoving);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ) * speed * Time.deltaTime;
        //anim.SetFloat("xVel", deltaX);
        //anim.SetFloat("zVel", deltaZ);
        movement = transform.TransformDirection(movement);

        countJump = countJump > 1 ? 0 : countJump;
        if (charController.isGrounded)
        {
            yVelocity = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpForce;
                //anim.SetTrigger("Jump");
                countJump++;
            }
        }
        else if (countJump == 1) {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpForce;
                //anim.SetTrigger("Jump");
                countJump = 0;
            }
        }

        yVelocity += gravity * Time.deltaTime;
        movement.y = yVelocity;
        charController.Move(movement);
    }
}
