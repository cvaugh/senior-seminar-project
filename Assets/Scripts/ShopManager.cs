using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Interactable {
    public string[] soldItems;
    public List<AbstractInventoryItem> inventory = new List<AbstractInventoryItem>();

    void Start() {
        foreach(string id in soldItems) {
            inventory.Add(ItemRegistry.GetById(id));
        }
    }

    public override void Interact(PlayerController player) {
        GameController.instance.shopUIManager.Show(this);
    }
}
