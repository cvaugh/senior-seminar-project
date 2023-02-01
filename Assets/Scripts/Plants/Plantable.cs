using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Plantable {
    public string name;
    public int growthStages;
    public int gridSize;
    public Transform[] growthStagePrefabs;
    public float growthRateFactor = 1.0f;
    // TODO

    public void validate() {
        Assert.IsNotNull(growthStagePrefabs);
        Assert.AreEqual(growthStages, growthStagePrefabs.Length);
        Assert.IsTrue(gridSize > 0);
    }
}
