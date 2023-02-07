using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    ObjectPool objectPool; //reference to object pool script
    [SerializeField] float timeToSpawn = 5f; //frequncy of object spawning
    private float timeSinceSpawn; //tracks how long since object last spawned

    private float xRange = 9.0f;
    private float zRange = 9.0f;

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
        timeSinceSpawn += Time.deltaTime; //creates a timer

        if (timeSinceSpawn >= timeToSpawn && newSphere != null)
        {

            newSphere.transform.position = RandomPos();
            newSphere.SetActive(true);
            timeSinceSpawn = 0f; //restarts timer

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


