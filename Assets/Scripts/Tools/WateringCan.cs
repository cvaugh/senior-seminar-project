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
            GameController.instance.inventoryManager.openButton.gameObject.SetActive(false);
            GameController.instance.inventoryManager.cancelWateringButton.gameObject.SetActive(true);
            GameController.instance.player.currentlyWatering = this;
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
            AudioRegistry.Play("sfx100v2_stones_02");
        }

        canUse = waterLevel > 0;

        if(!canUse) {
            GameController.instance.inventoryManager.StopWatering();
        }
    }
}
