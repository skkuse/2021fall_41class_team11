using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playTransform;
    Vector3 Offset;
    void Awake()
    {
        playTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playTransform.position;
    }
    void LateUpdate()
    { 
        transform.position = playTransform.position + Offset;
    }
}
