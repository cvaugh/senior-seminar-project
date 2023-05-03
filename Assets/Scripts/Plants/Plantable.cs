using UnityEngine;

public class Plantable : AbstractInventoryItem {
    private readonly string plant;

    public Plantable(string id, string name, string description, bool canUse, bool canDrop, int value, string plant)
            : base(id, name, description, canUse, canDrop, value) {
        this.plant = plant;
    }

    public override void Use(PlayerController player) {
        Camera.main.GetComponent<InventoryManager>().openButton.gameObject.SetActive(false);
        Camera.main.GetComponent<InventoryManager>().cancelPlantingButton.gameObject.SetActive(true);
        GameController.instance.HighlightPlantContainers(GetPlant().minContainerSize);
        player.currentlyPlanting = this;
    }

    public Plant GetPlant() {
        return PlantRegistry.GetById(plant);
    }
}
