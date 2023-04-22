using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour {
    public Transform inventoryCellPrefab;
    [HideInInspector]
    public Button openButton;
    [HideInInspector]
    public Button cancelPlantingButton;
    public Button cancelPlacementButton;
    private Transform inventoryParent;
    private Transform itemContainer;
    private Button closeButton;
    private Button useButton;
    private Button dropButton;
    private TMP_Text itemName;
    private TMP_Text itemInfo;

    void Start() {
        inventoryParent = GameController.instance.canvas.Find("Inventory");
        itemContainer = inventoryParent.Find("Inventory Scroll/Viewport/Inventory Contents");
        openButton = GameController.instance.canvas.Find("Inventory Open Button").GetComponent<Button>();
        openButton.onClick.AddListener(ShowInventory);
        closeButton = inventoryParent.Find("Close Button").GetComponent<Button>();
        closeButton.onClick.AddListener(HideInventory);
        useButton = inventoryParent.Find("Use Button").GetComponent<Button>();
        dropButton = inventoryParent.Find("Drop Button").GetComponent<Button>();
        itemName = inventoryParent.Find("Title Panel/Item Name").GetComponent<TMP_Text>();
        itemInfo = inventoryParent.Find("Info Panel/Item Info").GetComponent<TMP_Text>();
        cancelPlantingButton = GameController.instance.canvas.Find("Cancel Planting Button").GetComponent<Button>();
        cancelPlantingButton.onClick.AddListener(CancelPlanting);
        cancelPlacementButton = GameController.instance.canvas.Find("Cancel Placement Button").GetComponent<Button>();
        cancelPlacementButton.onClick.AddListener(CancelPlacement);
        HideInventory();
    }

    public void ShowInventory() {
        DeselectItem();
        GameController.instance.player.SortInventory();
        openButton.gameObject.SetActive(false);
        inventoryParent.gameObject.SetActive(true);
        for(int i = 0; i < GameController.instance.player.inventory.Count; i++) {
            Transform cell = Instantiate(inventoryCellPrefab, itemContainer);
            int cachedIndex = i;
            cell.GetComponent<Button>().onClick.AddListener(() => SelectItem(cachedIndex));
            cell.GetChild(0).GetComponent<Image>().sprite = GameController.instance.player.inventory[i].icon;
        }
    }

    public void HideInventory() {
        inventoryParent.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
        for(int i = itemContainer.childCount - 1; i >= 0; i--) {
            Destroy(itemContainer.GetChild(i).gameObject);
        }
    }

    public void UpdateInventory() {
        if(inventoryParent.gameObject.activeSelf) {
            HideInventory();
            ShowInventory();
        }
    }

    public void SelectItem(int index) {
        AbstractInventoryItem item = GameController.instance.player.inventory[index];
        itemName.text = item.name;
        itemInfo.text = item.description;
        useButton.enabled = item.canUse;
        useButton.onClick.RemoveAllListeners();
        if(item.canUse) {
            useButton.onClick.AddListener(() => {
                HideInventory();
                GameController.instance.player.UseItem(item);
            });
        }
        dropButton.enabled = item.canDrop;
        dropButton.onClick.RemoveAllListeners();
        if(item.canDrop) {
            dropButton.onClick.AddListener(() => {
                HideInventory();
                GameController.instance.player.DropItem(item);
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
        GameController.instance.UnHighlightPlantContainers();
        GameController.instance.player.currentlyPlanting = null;
    }

    public void StartPlacement(Transform prefab, float gridSize) {
        openButton.gameObject.SetActive(false);
        cancelPlacementButton.gameObject.SetActive(true);
        GameController.instance.player.currentlyPlacing = Instantiate(prefab,
            GameController.instance.player.transform.position, prefab.rotation);
        GameController.instance.player.placementGridSnapping = gridSize;
    }

    public void StartPlacement(Transform prefab) {
        StartPlacement(prefab, -1.0f);
    }

    public void CompletePlacement() {
        cancelPlacementButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
        GameController.instance.player.currentlyPlacing = null;
        GameController.instance.player.placementGridSnapping = -1.0f;
    }

    public void CancelPlacement() {
        Destroy(GameController.instance.player.currentlyPlacing.gameObject);
        CompletePlacement();
    }
}
