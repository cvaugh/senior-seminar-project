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
            value: 30
        ),
        new Placeable(
            id: "hoe",
            name: "Hoe",
            description: "A simple hoe.",
            canUse: true,
            canDrop: true,
            value: 150,
            gridSize: 1.2f,
            prefabId: "tilled_3x3",
            isConsumed: false
        ),
        new WateringCan(
            id: "watering_can",
            name: "Watering Can",
            description: "Used for watering plants.",
            canUse: true,
            canDrop: true,
            value: 100,
            maxUses: 5
        ),
        new GenericItem(
            id: "barley",
            name: "Barley",
            description: "A bundle of barley.",
            canUse: false,
            canDrop: true,
            value: 20
        ),
        new GenericItem(
            id: "beet",
            name: "Beet",
            description: "A beet.",
            canUse: false,
            canDrop: true,
            value: 25
        ),
        new GenericItem(
            id: "cabbage",
            name: "Cabbage",
            description: "A green cabbage.",
            canUse: false,
            canDrop: true,
            value: 40
        ),
        new GenericItem(
            id: "cauliflower",
            name: "Cauliflower",
            description: "A cauliflower.",
            canUse: false,
            canDrop: true,
            value: 35
        ),
        new GenericItem(
            id: "cotton",
            name: "Cotton",
            description: "A boll of cotton.",
            canUse: false,
            canDrop: true,
            value: 60
        ),
        new GenericItem(
            id: "gourd",
            name: "Gourd",
            description: "A calabash, also known as a bottle gourd or birdhouse gourd.",
            canUse: false,
            canDrop: true,
            value: 25
        ),
        new GenericItem(
            id: "onion_yellow",
            name: "Yellow Onion",
            description: "A yellow onion.",
            canUse: false,
            canDrop: true,
            value: 30
        ),
        new GenericItem(
            id: "quinoa",
            name: "Quinoa",
            description: "A bundle of quinoa.",
            canUse: false,
            canDrop: true,
            value: 25
        ),
        new GenericItem(
            id: "radish",
            name: "Radish",
            description: "A radish.",
            canUse: false,
            canDrop: true,
            value: 15
        ),
        new GenericItem(
            id: "rice",
            name: "Rice",
            description: "A bundle of rice.",
            canUse: false,
            canDrop: true,
            value: 10
        ),
        new GenericItem(
            id: "rye",
            name: "Rye",
            description: "A bundle of rye.",
            canUse: false,
            canDrop: true,
            value: 20
        ),
        new GenericItem(
            id: "tomato",
            name: "Tomato",
            description: "A tomato.",
            canUse: false,
            canDrop: true,
            value: 25
        ),
        new GenericItem(
            id: "turnip",
            name: "Turnip",
            description: "A turnip.",
            canUse: false,
            canDrop: true,
            value: 20
        ),
        new GenericItem(
            id: "watermelon",
            name: "Watermelon",
            description: "A watermelon.",
            canUse: false,
            canDrop: true,
            value: 35
        ),
        new GenericItem(
            id: "soybeans",
            name: "Soybeans",
            description: "Some soybeans.",
            canUse: false,
            canDrop: true,
            value: 30
        ),
        new GenericItem(
            id: "orange",
            name: "Orange",
            description: "An orange.",
            canUse: false,
            canDrop: true,
            value: 30
        ),
        new GenericItem(
            id: "eggplant",
            name: "Eggplant",
            description: "An eggplant.",
            canUse: false,
            canDrop: true,
            value: 25
        ),
        new Plantable(
            id: "seed_packet_eggplant",
            name: "Eggplant Seeds",
            description: "A small packet containing some eggplant seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "eggplant"
        ),
        new Placeable(
            id: "pot_1",
            name: "Medium Pot (Round)",
            description: "A medium-sized round terracotta pot.",
            canUse: true,
            canDrop: false,
            value: 100,
            gridSize: -1,
            prefabId: "pot_1",
            isConsumed: true
        ),
        new Placeable(
            id: "pot_2",
            name: "Large Pot (Round)",
            description: "A large, round terracotta pot.",
            canUse: true,
            canDrop: false,
            value: 250,
            gridSize: -1,
            prefabId: "pot_2",
            isConsumed: true
        ),
        new Placeable(
            id: "pot_3",
            name: "Small Pot (Round)",
            description: "A small, round plastic pot.",
            canUse: true,
            canDrop: false,
            value: 70,
            gridSize: -1,
            prefabId: "pot_3",
            isConsumed: true
        ),
        new Placeable(
            id: "pot_4",
            name: "Medium Pot (Square)",
            description: "A medium-sized square terracotta pot.",
            canUse: true,
            canDrop: false,
            value: 100,
            gridSize: -1,
            prefabId: "pot_4",
            isConsumed: true
        ),
        new Placeable(
            id: "pot_5",
            name: "Tall Pot (Round)",
            description: "A tall, ornate terracotta pot.",
            canUse: true,
            canDrop: false,
            value: 400,
            gridSize: -1,
            prefabId: "pot_5",
            isConsumed: true
        ),
        new Placeable(
            id: "pot_6",
            name: "Medium Pot (Square, Detailed)",
            description: "A medium-sized square terracotta pot with detailing.",
            canUse: true,
            canDrop: false,
            value: 150,
            gridSize: -1,
            prefabId: "pot_6",
            isConsumed: true
        ),
        new Plantable(
            id: "seed_packet_barley",
            name: "Barley Seeds",
            description: "A small packet containing some barley seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "barley"
        ),
        new Plantable(
            id: "seed_packet_rye",
            name: "Rye Seeds",
            description: "A small packet containing some rye seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "rye"
        ),
        new Plantable(
            id: "seed_packet_rice",
            name: "Rice Seeds",
            description: "A small packet containing some rice seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "rice"
        ),
        new Plantable(
            id: "seed_packet_cabbage",
            name: "Cabbage Seeds",
            description: "A small packet containing some cabbage seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "cabbage"
        ),
        new Plantable(
            id: "seed_packet_cauliflower",
            name: "Cauliflower Seeds",
            description: "A small packet containing some cauliflower seeds.",
            canUse: true,
            canDrop: true,
            value: 25,
            plant: "cauliflower"
        ),
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
