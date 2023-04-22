using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : AbstractInventoryItem {
    public readonly float maxWater;
    public float waterLevel = 0.0f;

    public WateringCan(string id, string name, string description, bool canUse, bool canDrop, int value, float maxWater) 
        : base(id, name, description, canUse, canDrop, value) {
        this.maxWater = maxWater;
    }

    public override void Use(PlayerController player) {
        // TODO
    }

    public void Refill() {
        waterLevel = maxWater;
    }
}
