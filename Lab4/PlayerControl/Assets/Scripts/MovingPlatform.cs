using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    enum PlatformMode
    {
        cycle,
        pingpong
    }

    [SerializeField]
    private List<Vector3> waypoints;
    private int waypointIndex = 0;
    private float speed = 3.0f;
    private bool isPaused = false;
    private int step = 0;
    private int maxStep = 2;
    private int minStep = 0;
    private bool isMax = false;
    [SerializeField]
    private PlatformMode mode = PlatformMode.pingpong;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPaused)
        {
            MovePlatform();
            if (transform.position == waypoints[waypointIndex])
            {
                StartCoroutine(pausePlatform());
                DetermineNewWaypoint();
            }
        }
    }

    IEnumerator pausePlatform()
    {
        isPaused = true;
        yield return new WaitForSeconds(1.0f);
        isPaused = false;
    }

    void MovePlatform()
    {
        float step = speed * Time.fixedDeltaTime;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoints[waypointIndex], step);
        transform.position = newPosition;
    }

    void DetermineNewWaypoint()
    {
        //yield return new WaitForSeconds(2.0f);

        if(mode == PlatformMode.pingpong)
        {
            if (!isMax)
            {
                waypointIndex++;
                step++;
                isMax = step == maxStep ? true : false;
            }
            else
            {
                waypointIndex--;
                step--;
                isMax = step == minStep ? false : true;
            }
        }
        else
        {
            waypointIndex++;
        }

        if (waypointIndex >= waypoints.Count)
        {
            waypointIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = transform;
        }
}

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
