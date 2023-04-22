using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class HoeItem : AbstractInventoryItem {
    private readonly float gridSize = 1.2f;
    private Transform tilledPrefab;

    public HoeItem(string id, string name, string description, bool canUse, bool canDrop, int value)
        : base(id, name, description, canUse, canDrop, value) {
        tilledPrefab = Resources.Load<Transform>("Containers/tilled_2x2");
        Assert.IsNotNull(tilledPrefab);
    }

    public override void Use(PlayerController player) {
        GameController.instance.inventoryManager.StartPlacement(tilledPrefab, gridSize);
    }
}
