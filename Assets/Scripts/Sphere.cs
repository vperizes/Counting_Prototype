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

    IEnumerator CallReturnSphere()
    {
        yield return new WaitForSeconds(1);
        objectPool.ReturnSphere(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(CallReturnSphere());
            
        }
        else
        {
            return;
        }
    }
}
