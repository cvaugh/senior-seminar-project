using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float globalGrowthRate = 5.0f;
    public GameObject inventoryUI;
    public GameObject openInventoryButton;
    private PlayerController player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        HideInventory();
    }

    void Update() {

    }

    public void ShowInventory() {
        player.SortInventory();
        openInventoryButton.SetActive(false);
        inventoryUI.SetActive(true);
    }

    public void HideInventory() {
        inventoryUI.SetActive(false);
        openInventoryButton.SetActive(true);
    }
}
