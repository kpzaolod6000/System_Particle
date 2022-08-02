using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update

    //camera will follow this target
    public Transform target;
    //change this value to get desired smoothness
    public float smoothTime = 0.3f;
    // this value will change at the runtime depending on target movement 
    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;

    void Start()
    {

        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
