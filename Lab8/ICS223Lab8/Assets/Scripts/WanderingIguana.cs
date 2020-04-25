using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingIguana : MonoBehaviour
{
    private float iguanaSpeed = 3.0f;
    private float obstacleRange = 9.0f;
    private Animator anim;
    private float turn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = iguanaSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Decide if we are headed for an obstacle so we can turn
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Test for a collision
        if (Physics.SphereCast(ray, 0.5f, out hit))
        {
            // Is there an obstacle in the way tha is close enough to warrant a turn?
            if(hit.distance < obstacleRange)
            {
                // If our turn value is not set(0), we need to decide on a left or right turn
                if (Mathf.Approximately(turn, 0.0f))
                {
                    // Flip a coin (0 or 1), 0 = left turn 1 = right turn
                    turn = Random.Range(0, 2) == 0 ? -0.75f : 0.75f;

                }

                // Blending will cause the iguana to move forward and turn at the same time
                // Turn quickly, move forward slowly
                Move(turn, 0.1f);
            }
            else
            {
                float forwardSpeed = Random.Range(0.05f, 1.0f);
                turn = 0.0f;    // set the turn value to 0 (will pick new direction at next turn)

                // No blending happends here since we are not turning
                Move(turn, forwardSpeed);
            }
        }
    }

    private void Move(float turn, float forward)
    {
        float dampTime = 0.2f;
        if (anim != null) {
            anim.SetFloat("Turn", turn, dampTime, Time.deltaTime);
            anim.SetFloat("Forward", forward, dampTime, Time.deltaTime);
        }
    }
}
