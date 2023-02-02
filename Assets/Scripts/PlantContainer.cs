using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlantContainer : MonoBehaviour {
    public float depth;
    private List<Transform> attachmentPoints = new List<Transform>();

    void Start() {
        Assert.IsTrue(depth >= 0.0f);
        for(int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if(child.tag == "AttachmentPoint") {
                attachmentPoints.Add(child);
            }
        }
        SetAttachmentPointVisibility(false);
    }

    void Update() {
        
    }

    public void SetAttachmentPointVisibility(bool visible) {
        foreach(Transform t in attachmentPoints) {
            t.GetComponent<MeshRenderer>().enabled = visible;
            t.GetComponent<MeshCollider>().enabled = visible;
        }
    }
}
