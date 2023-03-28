using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : Interactable {
    [HideInInspector]
    public int itemIndex = 0;
    public InventoryItem item;

    public void Init() {
        item = ItemRegistry.Items[itemIndex];
    }

    public override void Interact(PlayerController player) {
        PickUp(player);
    }

    public void PickUp(PlayerController player) {
        player.inventory.Add(item);
        player.SortInventory();
        Destroy(gameObject);
    }

    public static void Create(PlayerController player, InventoryItem item) {
        Transform dropped = Instantiate(item.prefab, player.itemDropPoint.position, Quaternion.identity);
        dropped.GetComponent<DroppedItem>().item = item;
        // Add small random force so the item will fall over
        dropped.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 0.2f;
        dropped.GetComponent<Rigidbody>().angularVelocity = Random.onUnitSphere * 0.2f;
    }
}
