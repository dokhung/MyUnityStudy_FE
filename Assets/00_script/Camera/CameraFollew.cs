using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollew : MonoBehaviour
{
    [Header("추적대상")]
    [SerializeField]
    private Transform target;

    [Header("Camera Setting")] 
    [SerializeField]
    private float smoothSpeed = 5f;

    [SerializeField] 
    private Vector3 offset = new Vector3(0, 1, -10);

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        
        Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
