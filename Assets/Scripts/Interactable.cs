using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = .9f;
    bool hasInteracted = false;

    private GameController gc;

    private void Start() {
        gc = Camera.main.GetComponent<GameController>();
    }

    public virtual void Interact() {
        //to be overwritten for each interactable
        Debug.Log("interacting with " + transform.name);
    }

    void Update() {
        if(gc.player.IsFocused(transform) && !hasInteracted) {
            float dist = Vector3.Distance(gc.player.transform.position, transform.position);
            if(dist <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocusChanged() {
        hasInteracted = false;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
