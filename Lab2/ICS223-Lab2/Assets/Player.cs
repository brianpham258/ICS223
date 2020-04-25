using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(RigidBody))]
public class Player : MonoBehaviour
{
    float speed = 20f;
    float force = 1000f;
    private Rigidbody rbody;
    float horizInput;
    float vertInput;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        // float horizMouse = Input.GetAxis("Mouse X");
        // float vertMouse = Input.GetAxis("Mouse Y");

        // Vector3 movement = new Vector3(horizInput, 0, vertInput) * speed * Time.deltaTime;
        // Vector3 mouse = new Vector3(horizMouse, 0, vertMouse) * speed * Time.deltaTime;

        // transform.Translate(movement);
        // transform.Translate(mouse);
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(horizInput, 0, vertInput) * force * Time.fixedDeltaTime;
        // rbody.AddForce(movement);
         rbody.velocity = movement;
        // rbody.MovePosition(transform.position + movement);
    }
}
