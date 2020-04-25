using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float deltaY;
    private Rigidbody rbody;
    private float speed = 7.0f;
    [SerializeField]
    private bool isLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        if (rbody == null)
        {
            Debug.LogError("padde missing rbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
        {
            deltaY = Input.GetAxis("Vertical");
        }
        else
        {
            deltaY = Input.GetAxis("Vertical2");
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, deltaY, 0) * Time.fixedDeltaTime * speed;
        //transform.Translate(movement);
        rbody.MovePosition(transform.position + movement);
    }
}
