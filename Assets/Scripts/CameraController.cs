using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public float followSpeed;
    private Vector3 offset;

    void Start() {
        offset = transform.position - target.position;
    }

    void Update() {
        float interpolation = followSpeed * Time.deltaTime;
        Vector3 pos = target.position + offset;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, pos.x, interpolation), pos.y,
                                         Mathf.Lerp(transform.position.z, pos.z, interpolation));
    }
}
