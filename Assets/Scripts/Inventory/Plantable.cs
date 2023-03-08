using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantable : InventoryItem {
    public readonly Plant plant;

    public Plantable(string id, string name, string description, bool canUse, bool canDrop, Plant plant)
            : base(id, name, description, canUse, canDrop) {
        this.plant = plant;
    }

    public new void Use(PlayerController player) {
        Camera.main.GetComponent<InventoryManager>().openButton.gameObject.SetActive(false);
        Camera.main.GetComponent<InventoryManager>().cancelPlantingButton.gameObject.SetActive(true);
        player.gc.HighlightPlantContainers(plant.minContainerSize);
        player.currentlyPlanting = this;
    }
}
