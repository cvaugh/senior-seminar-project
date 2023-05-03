using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : Interactable {

    public WateringCan wateringCan;
    public PlayerController player;

    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    
    public override void Interact(PlayerController player) {
        foreach (AbstractInventoryItem item in player.GetInventory()){
            if (item is WateringCan) {
                wateringCan = (WateringCan)item;
                Debug.Log(wateringCan.waterLevel);
            } 
        }
        if (wateringCan == null) {
            Debug.Log("not found");
        }
        if (player.GetInventory().Contains(wateringCan) && wateringCan.waterLevel < wateringCan.maxUses) {
            wateringCan.Refill();
            Debug.Log("Watering Can can and has been refilled.");
        }
        else if (wateringCan.waterLevel == wateringCan.maxUses) {
            Debug.Log("Watering can is already full");
        }
        else {
            Debug.Log("unkown error");
        }
    }
}
