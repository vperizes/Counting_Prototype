using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;


    [SerializeField] private GameObject spherePrefab;
    private int sphereCount = 30;
    private List<GameObject> spherePool;

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
        AddSpheres();
    }

    public void AddSpheres()
    {
        spherePool = new List<GameObject>();

        for (int i = 0; i < sphereCount; i++)
        {
            GameObject sphere = Instantiate(spherePrefab);
            sphere.SetActive(false);
            spherePool.Add(sphere); //Adds instatiated deactivated sphere to list
        }
    }

    public GameObject GetPooledSphere()
    {
        for (int i = 0; i < spherePool.Count; i++)
        {
            if (!spherePool[i].activeInHierarchy)
            {
                return spherePool[i];
            }

        }

        return null;

    }

 
}
