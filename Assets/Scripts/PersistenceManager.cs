using UnityEngine;
using System.IO;

public static class PersistenceManager {
    private static readonly string containersPath = Application.persistentDataPath + "/containers.dat";

    public static void Write() {
        BinaryWriter writer = new BinaryWriter(new FileStream(containersPath, FileMode.Create), System.Text.Encoding.UTF8);

        foreach(PlantContainer pc in Object.FindObjectsOfType<PlantContainer>()) {
            pc.Serialize(writer);
        }

        writer.Close();
    }

    public static void Load() {
        // TODO
    }
}
