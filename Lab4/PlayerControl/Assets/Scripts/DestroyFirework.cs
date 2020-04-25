using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFirework : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(KillFireWork());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator KillFireWork()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
