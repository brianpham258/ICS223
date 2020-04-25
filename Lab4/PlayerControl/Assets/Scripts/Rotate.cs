using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -20; x < 20; x += 5)
        {
            for (int y = -20; y < 20; y += 5)
            {
                for (int z = -20; z < 20; z += 5)
                {
                    Instantiate(sphere, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
