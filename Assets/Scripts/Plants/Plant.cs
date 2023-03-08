using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Plant {
    public readonly string id;
    public readonly int growthStages;
    public readonly int minContainerSize;
    public readonly Transform[] growthStagePrefabs;
    public readonly float growthRateFactor = 1.0f;

    public double plantedTime;
    public int currentGrowthStage = 0;

    private GameController gc;

    public Plant(string id, int growthStages, int minContainerSize, float growthRateFactor) {
        this.id = id;
        this.growthStages = growthStages;
        this.minContainerSize = minContainerSize;
        this.growthRateFactor = growthRateFactor;
        growthStagePrefabs = new Transform[growthStages];
        for(int i = 0; i < growthStages; i++) {
            Transform prefab = Resources.Load<Transform>("Plants/Prefabs/" + id + "/stage_" + i);
            if(prefab == null) {
                Debug.LogError("Prefab not found: Plants/Prefabs/" + id + "/stage_" + i);
            } else {
                growthStagePrefabs[i] = prefab;
            }
        }
        Validate();
    }

    public void SetPlantedTime() {
        plantedTime = GameController.CurrentTimeMillis();
    }

    public void Validate() {
        Assert.IsTrue(growthStages > 0);
        Assert.IsNotNull(growthStagePrefabs);
        Assert.IsTrue(minContainerSize > 0);
    }

    public void CheckIfShouldGrow() {
        if(currentGrowthStage == growthStages - 1) return;
        if(gc == null) gc = Camera.main.GetComponent<GameController>();
        double age = (GameController.CurrentTimeMillis() - plantedTime) / 1000.0;
        if(age > gc.globalGrowthRate * growthRateFactor * (currentGrowthStage + 1)) {
            currentGrowthStage++;
        }
    }

    public Transform GetCurrentPrefab() {
        return growthStagePrefabs[currentGrowthStage];
    }
}
