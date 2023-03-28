using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlantContainer : Interactable {
    public int maxSize;
    public Plant plant;
    public Transform plantAttachmentPoint;
    private Transform plantTransform;
    private int currentGrowthStage = -1;
    private float moisture = 0.0f;

    void Start() {
        Assert.IsTrue(maxSize > 0);
        plantAttachmentPoint = transform.GetChild(0);
        gc = Camera.main.GetComponent<GameController>();
    }

    void FixedUpdate() {
        // TODO update base moisture based on scene environment
        // write shader to mix wet/dry soil material
        moisture -= GameController.dryingRate;
        if(moisture < 0.0f) {
            moisture = 0.0f;
        }
        if(plant != null) {
            plant.Tick(GetMoisture());
            if(plant.currentGrowthStage != currentGrowthStage) {
                Destroy(plantTransform.gameObject);
                plantTransform = Instantiate(plant.GetCurrentPrefab(), plantAttachmentPoint.position, Quaternion.identity, plantAttachmentPoint);
                currentGrowthStage = plant.currentGrowthStage;
            }
        }
    }

    public override void Interact(PlayerController player) {
        // TODO
        throw new System.NotImplementedException();
    }

    public void PlacePlant(Plant plant) {
        this.plant = plant;
        currentGrowthStage = 0;
        plantTransform = Instantiate(plant.GetCurrentPrefab(), plantAttachmentPoint.position, Quaternion.identity, plantAttachmentPoint);
    }

    public float GetMoisture() {
        if(moisture > 1.0f) {
            return 1.0f;
        } else if(moisture < 0.0f) {
            return 0.0f;
        } else {
            return moisture;
        }
    }
}
