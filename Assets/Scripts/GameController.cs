using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private PlayerController player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        HideInventory();
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
}
