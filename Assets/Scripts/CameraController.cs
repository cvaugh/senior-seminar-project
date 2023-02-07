using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform target;
    private Vector3 offset;

    public float cameraSpeed = 0.35f;
    
    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate() {
        //transform.position = target.position + offset;
        Vector3 desiredPosition = target.position + offset;
        transform.position  = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
    }
}
