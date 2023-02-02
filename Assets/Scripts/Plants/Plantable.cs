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
    public float rootDepth;
    // TODO

    public void Validate() {
        Assert.IsTrue(growthStages > 0);
        Assert.IsNotNull(growthStagePrefabs);
        Assert.AreEqual(growthStages, growthStagePrefabs.Length);
        Assert.IsTrue(gridSize > 0);
        Assert.IsTrue(rootDepth >= 0.0f);
    }
}
