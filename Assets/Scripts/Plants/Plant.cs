using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Assertions;

public class Plant {
    public readonly string id;
    public readonly string name;
    public readonly int growthStages;
    public readonly int minContainerSize;
    public readonly Transform[] growthStagePrefabs;
    public readonly Transform harvestPrefab;
    public readonly Transform floweringPrefab;
    public readonly double growthRate;
    public readonly double growthStageDuration;
    public readonly double harvestStageDuration;
    public readonly string harvestItemId;

    public double growth = 0.0;
    public int currentGrowthStage = 0;

    public Plant(string id, string name, int growthStages, int minContainerSize, double growthRate,
                 double growthStageDuration, double harvestStageDuration, string harvestItemId) {
        this.id = id;
        this.name = name;
        this.growthStages = growthStages;
        this.minContainerSize = minContainerSize;
        this.growthRate = growthRate;
        this.growthStageDuration = growthStageDuration;
        this.harvestStageDuration = harvestStageDuration;
        this.harvestItemId = harvestItemId;
        growthStagePrefabs = new Transform[growthStages];
        for(int i = 0; i < growthStages; i++) {
            Transform prefab = Resources.Load<Transform>("Plants/Prefabs/" + id + "/stage_" + i);
            if(prefab == null) {
                Debug.LogError("Prefab not found: Plants/Prefabs/" + id + "/stage_" + i);
            } else {
                growthStagePrefabs[i] = prefab;
            }
        }
        harvestPrefab = Resources.Load<Transform>("Plants/Prefabs/" + id + "/harvest");
        if(harvestPrefab == null) {
            Debug.LogError("Prefab not found: Plants/Prefabs/" + id + "/harvest");
        }
        floweringPrefab = Resources.Load<Transform>("Plants/Prefabs/" + id + "/flowering");
        if(floweringPrefab == null) {
            Debug.LogError("Prefab not found: Plants/Prefabs/" + id + "/flowering");
        }
        Validate();
    }

    public void Validate() {
        Assert.IsTrue(growthStages > 0);
        Assert.IsNotNull(growthStagePrefabs);
        Assert.IsTrue(minContainerSize > 0);
    }

    public void Tick(float moisture) {
        growth += GetCurrentGrowthRate(moisture);
        if(growth > growthStageDuration * growthStages + harvestStageDuration) {
            currentGrowthStage = growthStages + 1;
        } else if(growth > growthStageDuration * growthStages) {
            currentGrowthStage = growthStages;
        } else if(currentGrowthStage < growthStages - 1 && growth > growthStageDuration * (currentGrowthStage + 1)) {
            currentGrowthStage++;
        }
    }

    public double GetCurrentGrowthRate(float moisture) {
        return GameController.baseGrowthRate * growthRate * (Math.Pow(1.9, moisture) - 0.9);
    }

    public bool CanHarvest() {
        return currentGrowthStage == growthStages + 1;
    }

    public void Harvest() {
        currentGrowthStage = growthStages - 1;
        growth = growthStageDuration * currentGrowthStage;
        GameController.instance.player.AddItem(ItemRegistry.GetItemById(harvestItemId));
    }

    public Transform GetCurrentPrefab() {
        if(currentGrowthStage == growthStages + 1) {
            return harvestPrefab;
        } else if(currentGrowthStage == growthStages) {
            return floweringPrefab;
        } else {
            return growthStagePrefabs[currentGrowthStage];
        }
    }

    public Plant Clone() {
        return new Plant(id, name, growthStages, minContainerSize, growthRate, growthStageDuration,
            harvestStageDuration, harvestItemId);
    }
}
