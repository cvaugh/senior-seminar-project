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
        Transform dropped = Instantiate(item.prefab, player.transform.position, Quaternion.identity);
        dropped.GetComponent<DroppedItem>().item = item;
    }
}
