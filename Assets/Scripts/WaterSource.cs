public class WaterSource : Interactable {

    public override void Interact(PlayerController player) {
        foreach(AbstractInventoryItem item in player.GetInventory()){
            if(item is WateringCan) {
                ((WateringCan)item).Refill();
            } 
        }
    }
}
