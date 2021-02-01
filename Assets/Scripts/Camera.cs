using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;

    void Start ()
    {
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        float desiredPositionZ = target.position.z + offset.z;

        transform.position = Vector3.Slerp(transform.position, new Vector3(0f,offset.y,desiredPositionZ), smoothSpeed);
    }
}
