using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public float globalGrowthRate = 5.0f;
    public SceneStartPoint[] sceneStartPoints;
    public Transform inventoryUIItem;
    public GameObject inventoryUI;
    public GameObject inventoryItemContainer;
    public GameObject inventoryItemName;
    public GameObject inventoryItemInfo;
    public GameObject inventoryOpenButton;
    public GameObject inventoryUseButton;
    public GameObject inventoryDropButton;
    public Transform loadingBlocker;
    private PlayerController player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(SceneData.currentScene != null) {
            foreach(SceneStartPoint ssp in sceneStartPoints) {
                if(ssp.fromScene == SceneData.currentScene) {
                    player.transform.position = ssp.point.position;
                    player.transform.rotation = ssp.point.rotation;
                }
            }
        }
        SceneData.currentScene = SceneManager.GetActiveScene().name;
        HideInventory();
        loadingBlocker.gameObject.SetActive(false);
    }

    void Update() {

    }

    public void ShowInventory() {
        player.SortInventory();
        inventoryOpenButton.SetActive(false);
        inventoryUI.SetActive(true);
    }

    public void HideInventory() {
        inventoryUI.SetActive(false);
        inventoryOpenButton.SetActive(true);
    }

    public void LoadScene(string scene) {
        loadingBlocker.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(scene);
    }
}
