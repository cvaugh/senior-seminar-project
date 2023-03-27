using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Assertions;

public class Plant {
    public readonly string id;
    public readonly int growthStages;
    public readonly int minContainerSize;
    public readonly Transform[] growthStagePrefabs;
    public readonly double growthRate;
    public readonly double growthStageDuration;

    public double growth = 0.0;
    public int currentGrowthStage = 0;

    public Plant(string id, int growthStages, int minContainerSize, double growthRate, double growthStageDuration) {
        this.id = id;
        this.growthStages = growthStages;
        this.minContainerSize = minContainerSize;
        this.growthRate = growthRate;
        this.growthStageDuration = growthStageDuration;
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

    public void Validate() {
        Assert.IsTrue(growthStages > 0);
        Assert.IsNotNull(growthStagePrefabs);
        Assert.IsTrue(minContainerSize > 0);
    }

    public void Tick(float moisture) {
        growth += GameController.baseGrowthRate * growthRate * (Math.Pow(1.9, moisture) - 0.9);
        if(currentGrowthStage < growthStages - 1 && growth > growthStageDuration * (currentGrowthStage + 1)) {
            currentGrowthStage++;
        }
    }

    public Transform GetCurrentPrefab() {
        return growthStagePrefabs[currentGrowthStage];
    }
}
