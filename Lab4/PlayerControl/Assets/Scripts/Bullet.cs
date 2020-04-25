using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject fireworkPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject firework = Instantiate(fireworkPrefab);
            firework.transform.position = transform.position;
        }

        //collision.contacts[0];
    }
}
