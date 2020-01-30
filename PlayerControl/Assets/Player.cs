using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 9.0f;
    private float rotationSpeed = 200.0f;
    private CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, 0, deltaY) * speed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
        //transform.Translate(movement);
    }
}
