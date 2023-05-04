public class WaterSource : Interactable {

    public override void Interact(PlayerController player) {
        foreach(AbstractInventoryItem item in PlayerController.inventory){
            if(item is WateringCan) {
                ((WateringCan)item).Refill();
                AudioRegistry.Play("sfx100v2_misc_02");
            } 
        }
    }
}
