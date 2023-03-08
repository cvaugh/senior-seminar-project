using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour {
    public Transform inventoryCellPrefab;
    [HideInInspector]
    public Button openButton;
    private GameController gc;
    private Transform inventoryParent;
    private Transform itemContainer;
    private Button closeButton;
    private Button useButton;
    private Button dropButton;
    private TMP_Text itemName;
    private TMP_Text itemInfo;
    private Button cancelPlantingButton;

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
        itemName = inventoryParent.Find("Title Panel/Item Name").GetComponent<TMP_Text>();
        itemInfo = inventoryParent.Find("Info Panel/Item Info").GetComponent<TMP_Text>();
        cancelPlantingButton = gc.canvas.Find("Cancel Planting Button").GetComponent<Button>();
        cancelPlantingButton.onClick.AddListener(CancelPlanting);
        HideInventory();
    }

    public void ShowInventory() {
        DeselectItem();
        gc.player.SortInventory();
        openButton.gameObject.SetActive(false);
        inventoryParent.gameObject.SetActive(true);
        for(int i = 0; i < gc.player.inventory.Count; i++) {
            Transform cell = Instantiate(inventoryCellPrefab, itemContainer);
            int cachedIndex = i;
            cell.GetComponent<Button>().onClick.AddListener(() => SelectItem(cachedIndex));
            cell.GetChild(0).GetComponent<Image>().sprite = gc.player.inventory[i].icon;
        }
    }

    public void HideInventory() {
        inventoryParent.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
        for(int i = itemContainer.childCount - 1; i >= 0; i--) {
            Destroy(itemContainer.GetChild(i).gameObject);
        }
    }

    public void SelectItem(int index) {
        InventoryItem item = gc.player.inventory[index];
        itemName.text = item.name;
        itemInfo.text = item.description;
        useButton.enabled = item.canUse;
        useButton.onClick.RemoveAllListeners();
        if(item.canUse) {
            useButton.onClick.AddListener(() => {
                HideInventory();
                gc.player.UseItem(item);
            });
        }
        dropButton.enabled = item.canDrop;
        dropButton.onClick.RemoveAllListeners();
        if(item.canDrop) {
            dropButton.onClick.AddListener(() => {
                HideInventory();
                gc.player.DropItem(item);
            });
        }
    }

    public void DeselectItem() {
        itemName.text = "";
        itemInfo.text = "";
        useButton.enabled = false;
        dropButton.enabled = false;
    }

    public void CancelPlanting() {
        cancelPlantingButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
        gc.UnHighlightPlantContainers();
        gc.player.currentlyPlanting = null;
    }
}
