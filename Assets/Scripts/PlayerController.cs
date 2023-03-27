using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Interactable focus;
    public GameController gc;
    public Transform itemDropPoint;
    public Plantable currentlyPlanting = null;
    private NavMeshAgent agent;
    private Transform target;
    private int raycastMask;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        gc = Camera.main.GetComponent<GameController>();
        itemDropPoint = transform.Find("Item Drop Point");
        raycastMask = ~((1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Ignore Raycast")));
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, raycastMask)) {
                if(currentlyPlanting != null && hit.transform.GetComponent<PlantContainer>() != null) {
                    PlantContainer pc = hit.transform.GetComponent<PlantContainer>();
                    if(pc.maxSize <= currentlyPlanting.plant.minContainerSize) {
                        pc.PlacePlant(currentlyPlanting.plant);
                        inventory.Remove(currentlyPlanting);
                        gc.inventoryManager.CancelPlanting();
                    }
                } else if(hit.collider.GetComponent<Interactable>() != null) {
                    SetFocus(hit.collider.GetComponent<Interactable>());
                } else {
                    agent.destination = hit.point;
                    RemoveFocus();
                }
            }
        }

        if(target != null && Vector3.Distance(transform.position, target.transform.position) > 0.3) {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void SortInventory() {
        inventory.Sort((a, b) => a.name.CompareTo(b.name));
    }

    public void UseItem(InventoryItem item) {
        item.Use(this);
    }

    public void DropItem(InventoryItem item) {
        inventory.Remove(item);
        DroppedItem.Create(this, item);
        Debug.Log("drop");
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
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z), transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }

    void SetFocus(Interactable newFocus) {
        if(newFocus != focus) {
            if(focus != null) {
                focus.OnFocusChanged();
            }
            focus = newFocus;
            FollowTarget(newFocus);
        }
        newFocus.OnFocusChanged();
    }

    void RemoveFocus() {
        if(focus != null){
            focus.OnFocusChanged();
        }
        focus = null;
        StopFollowingTarget();
    }

    public bool IsFocused(Transform t) {
        return focus != null && focus.transform == t;
    }
}
