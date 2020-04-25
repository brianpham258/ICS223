using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    [SerializeField]
    private Camera camera1, camera2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if(camera2.enabled)
            {
                camera2.enabled = false;
                camera1.enabled = true;
                camera1.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            }
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if(camera1.enabled)
            {
                camera1.enabled = false;
                camera2.enabled = true;
                camera2.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            camera1.enabled = true;
            camera2.enabled = true;
            camera1.rect = new Rect(0.0f, 0.5f, 1.0f, 0.5f);
            camera2.rect = new Rect(0.0f, 0.0f, 1.0f, 0.498f);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            camera1.enabled = true;
            camera2.enabled = true;
            camera1.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
            camera2.rect = new Rect(0.0f, 0.0f, 0.498f, 1.0f);
        }
    }
}
