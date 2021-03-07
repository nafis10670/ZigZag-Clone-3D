using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;
    
    public static List<GameObject> steppedObjects;

    public int pooledAmount;
    
    public List<GameObject> pooledObjects;


    void Start()
    {
        pooledObjects = new List<GameObject>();
        steppedObjects = new List<GameObject>();
        AddObjects();
    }

    void AddObjects()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
       // print("POOLED: " + pooledObjects.Count);
        foreach (var t in pooledObjects)
        {
            if (!t.activeInHierarchy)
            {
                //Debug.Log("created road " + i);
                return t;
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
