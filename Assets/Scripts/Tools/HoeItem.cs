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
        Vector3 playerPos = GameController.instance.player.transform.position;
        Vector3 pos = new Vector3(Mathf.Round(playerPos.x / gridSize) * gridSize, 0.01f,
                                  Mathf.Round(playerPos.z / gridSize) * gridSize);
        Collider[] nearby = Physics.OverlapSphere(pos, gridSize / 4.0f);
        foreach(Collider collider in nearby) {
            if(collider.GetComponent<PlantContainer>() != null || collider.tag == "DroppedItem") return;
        }
        Object.Instantiate(tilledPrefab, pos, tilledPrefab.rotation);
    }
}
