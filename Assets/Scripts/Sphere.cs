using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    ObjectPool objectPool;

    // Update is called once per frame
    private void Start()
    {
        objectPool = ObjectPool.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(DeactivateSphere());
        }

    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}