using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private NavMeshAgent agent;

    public Interactable focus;
    Transform target;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;

                RemoveFocus();
            }
        }

        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject()) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) {
                    SetFocus(interactable);
                }
            }
        }

        if(target != null) {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void SortInventory() {
        inventory.Sort((a, b) => a.name.CompareTo(b.name));
    }

    public void FollowTarget(Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius * .7f;
        agent.updateRotation = false;
        target = newTarget.transform;
    }

    public void StopFollowingTarget() {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }

    void SetFocus(Interactable newFocus) {
        if(newFocus != focus) {
            if(focus != null) {
                focus.DeFocused();
            }
            focus = newFocus;
            FollowTarget(newFocus);

        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus() {
        if(focus != null){
            focus.DeFocused();
        }
        focus = null;
        StopFollowingTarget();
    }
}
