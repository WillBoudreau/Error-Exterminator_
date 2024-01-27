using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    
    public Transform target;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        
        
        
        Vector3 targerPosition = target.position + offset;
        targerPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targerPosition, ref velocity, damping);
        
        

    }
}
