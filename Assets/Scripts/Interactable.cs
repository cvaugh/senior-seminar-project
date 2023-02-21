using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = .9f;

    bool isFocused = false;
    bool hasInteracted = false;
    Transform player;

    public virtual void Interact() {
        Debug.Log("interacting with " + transform.name);
    }

    void Update() {
        if(isFocused && !hasInteracted) {
            float dist = Vector3.Distance(player.position, transform.position);
            if(dist <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform) {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void DeFocused() {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
