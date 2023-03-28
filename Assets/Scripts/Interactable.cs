using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public bool canInteractAnywhere = false;
    public float radius = .9f;
    public bool hasInteracted = false;

    private void Start() {
        if(this is DroppedItem) {
            ((DroppedItem)this).Init();
        }
    }

    public abstract void Interact(PlayerController player);

    void Update() {
        if(GameController.instance.player.IsFocused(transform) && !hasInteracted) {
            float dist = Vector3.Distance(GameController.instance.player.transform.position, transform.position);
            if(dist <= radius) {
                Interact(GameController.instance.player);
                hasInteracted = true;
            }
        }
    }

    public void OnFocusChanged() {
        hasInteracted = false;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
