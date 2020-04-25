using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCanon : MonoBehaviour
{
    private float speed = 70.0f;
    private float maxAngle = 45.0f;
    private float minAngle = 135.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(135, 0, 0);
        // Rotate up
        if (Input.GetKey(KeyCode.R))
        {
            if (transform.rotation.eulerAngles.x > maxAngle)
            {
                transform.Rotate(Vector3.left * speed * Time.deltaTime);
            }

            //transform.Rotate(Vector3.left * speed * Time.deltaTime);
            //if (transform.eulerAngles.x > maxAngle)
            //{
            //    transform.eulerAngles = new Vector3(maxAngle, transform.eulerAngles.y, transform.eulerAngles.z);
            //}
        }

       
        // Rotate down
        if (Input.GetKey(KeyCode.F))
        {
            if (transform.rotation.eulerAngles.x < minAngle)
            {
                transform.Rotate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.eulerAngles = new Vector3(minAngle, 0, 0);
            }
        }
    }
}
