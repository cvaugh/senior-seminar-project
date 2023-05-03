using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : AbstractInventoryItem {
    public readonly int maxUses;
    public int waterLevel = 0;

    public WateringCan(string id, string name, string description, bool canUse, bool canDrop, int value, int maxUses) 
        : base(id, name, description, canUse, canDrop, value) {
        this.maxUses = maxUses;
        this.canUse = false;
    }

    public override void Use(PlayerController player) {
        if(waterLevel > 0) {
            GameController.instance.inventoryManager.openButton.gameObject.SetActive(true);
            GameController.instance.inventoryManager.cancelWateringButton.gameObject.SetActive(false);
            GameController.instance.player.currentlyWatering = true;
            waterLevel -= 1;
        }
    }

    public void Refill() {
        waterLevel = maxUses;
        canUse = waterLevel > 0;
    }

    public void Water(PlantContainer container) {
        if(waterLevel > 0) {
            container.SetMoisture(1.0f);
            waterLevel -= 1;
        }
        if(waterLevel == 0) {
            GameController.instance.inventoryManager.StopWatering();
        }
        canUse = waterLevel > 0;
    }
}
