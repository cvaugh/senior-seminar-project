using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public static double baseGrowthRate = 0.1;
    public static float dryingRate = 0.0001f;
    public SceneStartPoint[] sceneStartPoints;
    public Transform loadingBlocker;
    public Material highlightMaterial;

    public PlayerController player;
    public InventoryManager inventoryManager;
    public ShopUIManager shopUIManager;
    public PlantInfoManager plantInfoManager;
    public Transform canvas;
    public Dictionary<GameObject, Material> highlightedObjects = new Dictionary<GameObject, Material>();

    void Awake() {
        instance = this;
        ItemRegistry.Init();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        inventoryManager = GetComponent<InventoryManager>();
        shopUIManager = GetComponent<ShopUIManager>();
        plantInfoManager = GetComponent<PlantInfoManager>();
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
        BalanceManager.Set(200); // FOR DEMO ONLY
    }

    private void OnApplicationQuit() {
        PersistenceManager.Write();
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
}

