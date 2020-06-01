using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 targetPosition = new Vector3(target.position.x,
                                        target.position.y,
                                        transform.position.z
                                        );
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
        //transform.LookAt(target);
    }
}
