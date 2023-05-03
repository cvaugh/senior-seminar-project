using UnityEngine;

public abstract class AbstractInventoryItem {
    public readonly string id;
    public string name;
    public string description;
    public bool canUse = true;
    public bool canDrop = true;
    public Transform prefab;
    public Sprite icon;
    public int value;

    public AbstractInventoryItem(string id, string name, string description, bool canUse, bool canDrop, int value) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.canUse = canUse;
        this.canDrop = canDrop;
        this.value = value;
    }

    public abstract void Use(PlayerController player);

    public bool IsPurchasable() {
        return value >= 0;
    }
}
