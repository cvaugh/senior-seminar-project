using System.Collections.Generic;

public static class PlantRegistry {
    public static readonly List<Plant> Plants = new List<Plant> {
        new Plant(
            id: "plant_generic",
            name: "Generic Plant",
            growthStages: 1,
            minContainerSize: 1,
            growthRate: 1.0,
            growthStageDuration: 1.0,
            harvestStageDuration: 1.0,
            harvestItemId: "pinto_beans",
            destroyOnHarvest: true
        ),
        new Plant(
            id: "pinto_bean",
            name: "Pinto Bean",
            growthStages: 4,
            minContainerSize: 1,
            growthRate: 1.0,
            growthStageDuration: 20.0,
            harvestStageDuration: 40.0,
            harvestItemId: "pinto_beans",
            destroyOnHarvest: false
        ),
        new Plant(
            id: "wheat_plant",
            name: "Wheat",
            growthStages: 4,
            minContainerSize: 3,
            growthRate: 1.0,
            growthStageDuration: 40.0,
            harvestStageDuration: 40.0,
            harvestItemId: "wheat",
            destroyOnHarvest: true
        )
    };

    public static Plant GetById(string id) {
        foreach(Plant plant in Plants) {
            if(plant.id.Equals(id)) return plant;
        }
        return null;
    }
}
