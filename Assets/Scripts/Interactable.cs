using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public float radius = .9f;
    bool hasInteracted = false;

    private GameController gc;

    private void Start() {
        gc = Camera.main.GetComponent<GameController>();
        if(this is DroppedItem) {
            ((DroppedItem)this).Init();
        }
    }

    public abstract void Interact(PlayerController player);

    void Update() {
        if(gc.player.IsFocused(transform) && !hasInteracted) {
            float dist = Vector3.Distance(gc.player.transform.position, transform.position);
            if(dist <= radius) {
                Interact(gc.player);
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
