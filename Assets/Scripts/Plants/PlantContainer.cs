using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlantContainer : Interactable {
    public int maxSize;
    public float constantMoisture = -1f;
    public Plant plant;
    public Transform plantAttachmentPoint;
    private Transform plantTransform;
    private int currentGrowthStage = -1;
    private float moisture = 0.0f;

    void Start() {
        Assert.IsTrue(maxSize > 0);
        plantAttachmentPoint = transform.GetChild(0);
        canInteractAnywhere = true;
    }

    void FixedUpdate() {
        // TODO update base moisture based on scene environment
        // write shader to mix wet/dry soil material
        if(constantMoisture >= 0.0f) {
            moisture = constantMoisture;
        } else {
            moisture -= GameController.dryingRate;
        }
        if(moisture < 0.0f) {
            moisture = 0.0f;
        }
        if(plant != null) {
            plant.Tick(GetMoisture());
            if(plant.currentGrowthStage != currentGrowthStage) {
                Destroy(plantTransform.gameObject);
                plantTransform = Instantiate(plant.GetCurrentPrefab(), plantAttachmentPoint.position, Quaternion.identity, plantAttachmentPoint);
                plantTransform.localRotation = Quaternion.identity;
                currentGrowthStage = plant.currentGrowthStage;
            }
        }
    }

    public override void Interact(PlayerController player) {
        if(plant == null) {
            // TODO pick up
            throw new System.NotImplementedException();
        } else {
            GameController.instance.plantInfoManager.Show(this);
        }
    }

    public void PlacePlant(Plant plant) {
        this.plant = plant;
        currentGrowthStage = 0;
        plantTransform = Instantiate(plant.GetCurrentPrefab(), plantAttachmentPoint.position, Quaternion.identity, plantAttachmentPoint);
        plantTransform.localRotation = Quaternion.identity;
    }

    public void RemovePlant() {
        plant = null;
        currentGrowthStage = -1;
        Destroy(plantTransform.gameObject);
    }

    public float GetMoisture() {
        return Mathf.Clamp01(moisture);
    }
    
    public void SetMoisture(float moisture) {
        this.moisture = Mathf.Clamp01(moisture);
    }
}
