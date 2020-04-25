using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletSpawn;
    private float speed = 50.0f;
    private float mouseDown;
    private float baseSpeed = 50.0f;
    private float baseChargeTime = 0.5f;
    private float minRatio = 0.5f;
    private float maxRatio = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            mouseDown = Time.time;
        }
        if (mouseDown > 0 && Input.GetButtonUp("Fire1"))
        {
            float holdTime = getHoldTime();
            float ratio = getRatio(holdTime);
            float adjustedSpeed = ratio * baseSpeed;
            adjustedSpeed = Mathf.Clamp(adjustedSpeed, minRatio*baseSpeed, maxRatio*baseSpeed);
            Fire(adjustedSpeed);
            mouseDown = 0;
            Debug.Log("ratio:" + getRatio(holdTime) + "time: " + holdTime + "speed: " + adjustedSpeed);
        }

        if(mouseDown > 0)
        {
            float ratio = getRatio(getHoldTime());
            if (ratio > maxRatio)
            {
                float speed = baseSpeed * maxRatio;
                Fire(speed);
                mouseDown = 0;
                Debug.Log("ratio:" + ratio + ", time: " + getHoldTime() + ", speed: " + speed );
            }
        }
    }

    float getHoldTime()
    {
        float holdTime = Time.time - mouseDown;
        return holdTime;
    }

    float getRatio(float actualTime)
    {
        float ratio = actualTime / baseChargeTime;
        return ratio;
    }

    void Fire(float speed)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawn.transform.position;

        Vector3 rot = bullet.transform.eulerAngles;
        rot.y = transform.eulerAngles.y;
        bullet.transform.eulerAngles = rot;

        Rigidbody rbody = bullet.GetComponent<Rigidbody>();
        rbody.AddForce(bulletSpawn.transform.forward * speed, ForceMode.Impulse);

        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(bullet);
    }
}
