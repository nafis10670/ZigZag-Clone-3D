using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Awake()
    {
        this.offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        this.transform.position = target.position + offset; 
    }
}
