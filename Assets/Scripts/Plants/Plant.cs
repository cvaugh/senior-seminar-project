using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Plant {
    public readonly string id;
    public readonly string name;
    public readonly int growthStages;
    public readonly int minContainerSize;
    public readonly Transform[] growthStagePrefabs;
    public readonly float growthRateFactor = 1.0f;

    public double plantedTime;
    public int currentGrowthStage = 0;

    public Plant(string id, string name, int growthStages, int minContainerSize, float growthRateFactor) {
        this.id = id;
        this.name = name;
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
        plantedTime = System.DateTime.Now.ToUniversalTime().Subtract(
            new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds;
    }

    public void Validate() {
        Assert.IsTrue(growthStages > 0);
        Assert.IsNotNull(growthStagePrefabs);
        Assert.IsTrue(minContainerSize > 0);
    }

    public void CheckIfShouldGrow() {
        // TODO
    }

    public Transform GetCurrentPrefab() {
        return growthStagePrefabs[currentGrowthStage];
    }
}
