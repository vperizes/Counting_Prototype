using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;


    [SerializeField] private GameObject spherePrefab;
    private int sphereCount = 30;
    private Queue<GameObject> spherePool;

    //singleton to call in other scripts
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        spherePool = new Queue<GameObject>();

        for (int i = 0; i < sphereCount; i++)
        {
            GameObject sphere = Instantiate(spherePrefab);
            sphere.SetActive(false);
            spherePool.Enqueue(sphere); //puts instatiated deactivated sphere in the queue 
        }
    }

    public GameObject GetPooledSphere()
    {
        GameObject sphere = spherePool.Dequeue();
        sphere.SetActive(true);
        return sphere;

        /*
        if (spherePool.Count > 0)
        {
            GameObject sphere = spherePool.Dequeue();
            sphere.SetActive(true);
            return sphere;
        }

        else
        {
            GameObject sphere = Instantiate(spherePrefab);
            return sphere;
        }
        */
    }

    //return sphere to pooled queue
    public void ReturnSphere(GameObject sphere)
    {
        spherePool.Enqueue(sphere);
        sphere.SetActive(false);
    }

}
