using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemRegistry {
    public static readonly List<InventoryItem> Items = new List<InventoryItem> {
        new Plantable("seed_packet_generic", "Seed Packet", "A small packet containing some seeds.", true, true,
            new Plant("plant_generic", "Generic Plant", 1, 1, 1.0, 1.0, 1.0, "pinto_beans")),
        new Plantable("seed_packet_pinto_bean", "Pinto Bean Seeds", "A small packet containing some pinto bean seeds.", true, true,
            new Plant("pinto_bean", "Pinto Bean", 4, 1, 1.0, 20.0, 40.0, "pinto_beans")),
        new InventoryItem("pinto_beans", "Pinto Beans", "Some pinto beans.", false, true)
    };

    public static void Init() {
        foreach(InventoryItem item in Items) {
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

    public static InventoryItem GetById(string id) {
        foreach(InventoryItem item in Items) {
            if(item.id.Equals(id)) return item;
        }
        return null;
    }
}
