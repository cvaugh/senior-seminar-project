using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInventoryItem {
    public readonly string id;
    public string name;
    public string description;
    public bool canUse = true;
    public bool canDrop = true;
    public Transform prefab;
    public Sprite icon;

    public AbstractInventoryItem(string id, string name, string description, bool canUse, bool canDrop) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.canUse = canUse;
        this.canDrop = canDrop;
    }

    public abstract void Use(PlayerController player);
}
