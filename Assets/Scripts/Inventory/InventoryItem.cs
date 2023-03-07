using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem {
    public readonly string id;
    public string name;
    public string description;
    public bool canUse = true;
    public bool canDrop = true;
    public Transform prefab;
    public Sprite icon;

    public InventoryItem(string id, string name, string description, bool canUse, bool canDrop) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.canUse = canUse;
        this.canDrop = canDrop;
    }

    public void Use(PlayerController player) {
        if(this is Plantable) {
            ((Plantable)this).Use(player);
        }
    }
}
