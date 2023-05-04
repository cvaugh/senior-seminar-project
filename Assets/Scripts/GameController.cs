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
    public AudioSource sfxSource;

    public PlayerController player;
    public InventoryManager inventoryManager;
    public ShopUIManager shopUIManager;
    public PlantInfoManager plantInfoManager;
    public Transform canvas;
    public Dictionary<GameObject, Material> highlightedObjects = new Dictionary<GameObject, Material>();

    void Awake() {
        instance = this;
        ItemRegistry.Init();
        AudioRegistry.Init();
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
        BalanceManager.Set(500); // FOR DEMO ONLY
    }

    private void OnApplicationQuit() {
        PersistenceManager.Write();
    }

    public void LoadScene(string scene) {
        loadingBlocker.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(scene);
    }

    public void PlaySound(string key) {
        AudioRegistry.Play(key);
    }
}
