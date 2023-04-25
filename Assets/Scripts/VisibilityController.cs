using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour {
    public MeshRenderer target;
    public bool startVisible;

    void Start() {
        SetVisible(startVisible);
    }

    private void SetVisible(bool visible) {
        if(visible) {
            target.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        } else {
            target.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player") {
            SetVisible(false);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player") {
            SetVisible(true);
        }
    }
}
