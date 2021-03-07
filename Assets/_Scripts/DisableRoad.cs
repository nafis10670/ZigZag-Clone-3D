using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class DisableRoad : MonoBehaviour
{
    //public ObjectPooler _objectPooler;

    private void Awake()
    {
        
        //_objectPooler = this.transform.parent.transform.parent.gameObject.GetComponent<ObjectPooler>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //count++;
            //Debug.Log(gameObject.transform.parent.gameObject.name);
            ObjectPooler.steppedObjects.Add(this.gameObject.transform.parent.gameObject);
            //print("POOLED OBJECTS: " + ObjectPooler.pooledObjects.Count);
        }

        if (ObjectPooler.steppedObjects.Count >= 3 && other.CompareTag("Player"))
        {
            //print("Entered Loop");
            //Debug.Log(ObjectPooler.pooledObjects[0].name);
            ObjectPooler.steppedObjects[0].gameObject.SetActive(false);
            GameManager.instance.canAppear = true;
            ObjectPooler.steppedObjects.RemoveAt(0);
            
        }

        /*if (other.CompareTag("Player"))
        {
            this.transform.parent.gameObject.SetActive(false);
            //Debug.Log("disabled");
            GameManager.instance.canAppear = true;
        }*/
    }
}
