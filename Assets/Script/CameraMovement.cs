﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    private Vector3 velocity = Vector3.zero;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 targetPosition = new Vector3(target.position.x,
                                        target.position.y,
                                        transform.position.z
                                        );
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
    }
}
