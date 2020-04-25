using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rbody;
    public float speed = 9.0f;
    private float xMin = -10;
    private float xMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        if (rbody == null)
        {
            Debug.LogError("padde missing rbody");
        }

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xMin)
        {
            Reset();
        }
        else if (transform.position.x > xMax)
        {
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = Vector3.zero;

        float xVel = Random.Range(0, 2) == 0 ? -1 : 1;
        float yVel = Random.Range(0, 2) == 0 ? -1 : 1;

        Vector3 movement = new Vector3(xVel, yVel, 0) * speed;
        rbody.velocity = movement;
    }
}
