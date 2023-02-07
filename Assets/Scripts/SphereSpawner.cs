using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    ObjectPool objectPool;

    private float xRange = 4.0f;
    private float zRange = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = ObjectPool.Instance;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnSphere();

    }

    private GameObject SpawnSphere()
    {
        GameObject newSphere = objectPool.GetPooledSphere();
        if (newSphere != null)
        {
            newSphere.transform.position = RandomPos();
            newSphere.SetActive(true);
        }
        return newSphere;
    }


    private Vector3 RandomPos()
    {
        float spawnX = Random.Range(-xRange, xRange);
        float spawnZ = Random.Range(-zRange, zRange);
        Vector3 randomPos = new Vector3(spawnX, 20, spawnZ);
        return randomPos;
    }



}


