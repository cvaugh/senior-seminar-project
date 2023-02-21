using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    private GameController gc;
    private Transform inventoryParent;
    private Transform itemContainer;
    private Transform openButton;
    private Transform closeButton;
    private Transform useButton;
    private Transform dropButton;
    private Text itemName;
    private Text itemInfo;

    void Start() {
        gc = Camera.main.GetComponent<GameController>();
        inventoryParent = gc.canvas.Find("Inventory");
        itemContainer = inventoryParent.Find("Inventory Scroll/Viewport/Inventory Contents");
        openButton = gc.canvas.Find("Inventory Open Button");
        openButton.GetComponent<Button>().onClick.AddListener(ShowInventory);
        closeButton = inventoryParent.Find("Close Button");
        closeButton.GetComponent<Button>().onClick.AddListener(HideInventory);
        useButton = inventoryParent.Find("Use Button");
        dropButton = inventoryParent.Find("Drop Button");
        itemName = inventoryParent.Find("Title Panel/Item Name").GetComponent<Text>();
        itemInfo = inventoryParent.Find("Info Panel/Item Info").GetComponent<Text>();
        HideInventory();
    }

    public void ShowInventory() {
        gc.player.SortInventory();
        openButton.gameObject.SetActive(false);
        inventoryParent.gameObject.SetActive(true);
    }

    public void HideInventory() {
        inventoryParent.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
    }
}
