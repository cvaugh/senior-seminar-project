using System.Collections.Generic;
using UnityEngine;

public static class ItemRegistry {
    public static readonly List<AbstractInventoryItem> Items = new List<AbstractInventoryItem> {
        new Plantable(
            id: "seed_packet_generic",
            name: "Seed Packet",
            description: "A small packet containing some seeds.",
            canUse: true,
            canDrop: true,
            value: -1,
            plant: "plant_generic"
        ),
        new Plantable(
            id: "seed_packet_bean_pinto",
            name: "Pinto Bean Seeds",
            description: "A small packet containing some pinto bean seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "pinto_bean"
        ),
        new Plantable(
            id: "seed_packet_wheat",
            name: "Wheat Seeds",
            description: "A small packet containing some wheat seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "wheat_plant"
        ),
        new GenericItem(
            id: "pinto_beans",
            name: "Pinto Beans",
            description: "Some pinto beans.",
            canUse: false,
            canDrop: true,
            value: 5
        ),
        new GenericItem(
            id: "wheat",
            name: "Wheat",
            description: "A bundle of wheat.",
            canUse: false,
            canDrop: true,
            value: 20
        ),
        new Placeable(
            id: "hoe",
            name: "Hoe",
            description: "A simple hoe.",
            canUse: true,
            canDrop: true,
            value: 100,
            gridSize: 1.2f,
            prefabId: "tilled_3x3"
        )
    };

    public static void Init() {
        // TODO: use JSON files instead
        foreach(AbstractInventoryItem item in Items) {
            Transform prefab = Resources.Load<Transform>("Items/Prefabs/" + item.id);
            if(prefab == null) {
                Debug.LogError("Item prefab not found: " + item.id);
            } else {
                item.prefab = prefab;
            }
            Sprite icon = Resources.Load<Sprite>("Items/Icons/" + item.id);
            if(icon == null) {
                Debug.LogError("Item icon not found: " + item.id);
                item.icon = Resources.Load<Sprite>("Items/Icons/placeholder");
            } else {
                item.icon = icon;
            }
        }
    }

    public static AbstractInventoryItem GetById(string id) {
        foreach(AbstractInventoryItem item in Items) {
            if(item.id.Equals(id)) return item;
        }
        return null;
    }
}
