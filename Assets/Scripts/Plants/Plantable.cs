using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Plantable {
    public string name;
    public int growthStages;
    public int gridSize;
    public Transform[] growthStagePrefabs;
    public float[] rootDepths;
    public float growthRateFactor = 1.0f;

    public void Validate() {
        Assert.IsTrue(growthStages > 0);
        Assert.IsNotNull(growthStagePrefabs);
        Assert.IsNotNull(rootDepths);
        Assert.AreEqual(growthStages, growthStagePrefabs.Length);
        Assert.AreEqual(growthStages, rootDepths.Length);
        Assert.IsTrue(gridSize > 0);
    }
}
