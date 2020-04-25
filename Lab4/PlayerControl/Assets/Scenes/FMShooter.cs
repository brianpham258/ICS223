using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMShooter : MonoBehaviour
{
    [SerializeField] private GameObject faceMaskPrefab;
    [SerializeField] private GameObject faceMaskSpawn;
    private float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire(speed);
        }
    }

    void Fire(float speed)
    {
        GameObject faceMask = Instantiate(faceMaskPrefab);
        faceMask.transform.position = faceMaskSpawn.transform.position;

        Vector3 rot = faceMask.transform.eulerAngles;
        rot.y = transform.eulerAngles.y;
        faceMask.transform.eulerAngles = rot;

        Rigidbody rbody = faceMask.GetComponent<Rigidbody>();
        rbody.AddForce(faceMaskSpawn.transform.forward * speed, ForceMode.Impulse);

        StartCoroutine(DestroyFaceMask(faceMask));
    }

    IEnumerator DestroyFaceMask(GameObject bullet)
    {
        yield return new WaitForSeconds(7.0f);
        Destroy(bullet);
    }

    private void OnTriggerEnter(Collider other)
    {
        //ReactiveTarget target = other.GetComponent<ReactiveTarget>();

        //if(target != null) { target.ReactToFaceMaskHit(); }
    }
}
