public class WaterSource : Interactable {

    public override void Interact(PlayerController player) {
        foreach(AbstractInventoryItem item in PlayerController.inventory){
            if(item is WateringCan) {
                ((WateringCan)item).Refill();
            } 
        }
    }
}
