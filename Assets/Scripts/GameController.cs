using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public float globalGrowthRate = 5.0f;
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
        SceneData.currentScene = SceneManager.GetActiveScene().name;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
