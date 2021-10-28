using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;
    public GameObject o1;
    public GameObject o2;
    public List<GameObject> objectToPool;
    //public GameObject objectToPool2;
    //public GameObject objectToPool3;
    public int amountToPool;
    public List<GameObject> pooledObjects;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        objectToPool.Add(o1);
        objectToPool.Add(o2);
        //Debug.Log(objectToPool);
        
        BuildPool(0,2);
        //Debug.Log(pooledObjects.Count);
    }

    private void BuildPool(int index=0)
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool[0]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    private void BuildPool(int min, int max)
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool[Random.Range(min,max)]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    // Return pooled object if it is not in the active hierarchy
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
