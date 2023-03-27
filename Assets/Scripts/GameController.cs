using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static double baseGrowthRate = 1.0;
    public static float dryingRate = 0.01f;
    public SceneStartPoint[] sceneStartPoints;
    public Transform loadingBlocker;
    public Material highlightMaterial;

    public PlayerController player;
    public InventoryManager inventoryManager;
    public Transform canvas;
    public Dictionary<GameObject, Material> highlightedObjects = new Dictionary<GameObject, Material>();

    void Awake() {
        ItemRegistry.Init();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        inventoryManager = GetComponent<InventoryManager>();
        canvas = GameObject.Find("Canvas").transform;
    }

    void Start() {
        if(SceneData.currentScene != null) {
            foreach(SceneStartPoint ssp in sceneStartPoints) {
                if(ssp.fromScene == SceneData.currentScene) {
                    player.transform.position = ssp.point.position;
                    player.transform.rotation = ssp.point.rotation;
                }
            }
        }
        SceneData.currentScene = SceneManager.GetActiveScene().name;
        loadingBlocker.gameObject.SetActive(false);
    }

    public void LoadScene(string scene) {
        loadingBlocker.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(scene);
    }

    public void HighlightPlantContainers(int minSize) {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("PlantContainer")) {
            PlantContainer pc = obj.GetComponent<PlantContainer>();
            if(pc == null || pc.maxSize < minSize || pc.plant != null) continue;
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            highlightedObjects.Add(obj, renderer.material);
            renderer.material = highlightMaterial;
        }
    }

    public void UnHighlightPlantContainers() {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("PlantContainer")) {
            obj.GetComponent<MeshRenderer>().material = highlightedObjects[obj];
        }
        highlightedObjects.Clear();
    }

    public static double CurrentTimeMillis() {
        return System.DateTime.Now.ToUniversalTime().Subtract(System.DateTime.UnixEpoch).TotalMilliseconds;
    }
}

