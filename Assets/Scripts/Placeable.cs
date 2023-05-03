using UnityEngine;
using UnityEngine.Assertions;

public class Placeable : AbstractInventoryItem {
    private readonly float gridSize = 1.2f;
    private readonly Transform placeablePrefab;

    public Placeable(string id, string name, string description, bool canUse, bool canDrop, int value, float gridSize, string prefabId)
        : base(id, name, description, canUse, canDrop, value) {
        this.gridSize = gridSize;
        placeablePrefab = Resources.Load<Transform>("Placeables/" + prefabId);
        Assert.IsNotNull(placeablePrefab);
    }

    public override void Use(PlayerController player) {
        GameController.instance.inventoryManager.StartPlacement(placeablePrefab, gridSize);
    }
}
