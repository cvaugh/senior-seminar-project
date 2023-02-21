using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    private GameController gc;
    private Transform inventoryParent;
    private Transform itemContainer;
    private Button openButton;
    private Button closeButton;
    private Button useButton;
    private Button dropButton;
    private Text itemName;
    private Text itemInfo;

    void Start() {
        gc = Camera.main.GetComponent<GameController>();
        inventoryParent = gc.canvas.Find("Inventory");
        itemContainer = inventoryParent.Find("Inventory Scroll/Viewport/Inventory Contents");
        openButton = gc.canvas.Find("Inventory Open Button").GetComponent<Button>();
        openButton.onClick.AddListener(ShowInventory);
        closeButton = inventoryParent.Find("Close Button").GetComponent<Button>();
        closeButton.onClick.AddListener(HideInventory);
        useButton = inventoryParent.Find("Use Button").GetComponent<Button>();
        dropButton = inventoryParent.Find("Drop Button").GetComponent<Button>();
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

    public void SelectItem(InventoryItem item) {
        itemName.text = item.name;
        itemInfo.text = item.description;
        useButton.enabled = item.canUse;
        dropButton.enabled = item.canDrop;
    }

    public void DeselectItem() {
        itemName.text = "";
        itemInfo.text = "";
        useButton.enabled = false;
        dropButton.enabled = false;
    }
}
