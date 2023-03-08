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

    void Start() {
        Assert.IsTrue(maxSize > 0);
        plantAttachmentPoint = transform.GetChild(0);
    }

    void Update() {
        plant.CheckIfShouldGrow();
        if(plant.currentGrowthStage != currentGrowthStage) {
            Destroy(plantTransform.gameObject);
            plantTransform = Instantiate(plant.GetCurrentPrefab(), plantAttachmentPoint.position, Quaternion.identity, plantAttachmentPoint);
            currentGrowthStage = plant.currentGrowthStage;
        }
    }

    public override void Interact(PlayerController player) {
        // TODO
        throw new System.NotImplementedException();
    }

    public void PlacePlant(Plant plant) {
        this.plant = plant;
        plant.SetPlantedTime();
        currentGrowthStage = 0;
        plantTransform = Instantiate(plant.GetCurrentPrefab(), plantAttachmentPoint.position, Quaternion.identity, plantAttachmentPoint);
    }
}
