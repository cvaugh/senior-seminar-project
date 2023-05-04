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
    public Button cancelWateringButton;
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
        openButton.onClick.AddListener(() => {
            ShowInventory();
            AudioRegistry.Play("sfx100v2_misc_32");
        });
        closeButton = inventoryParent.Find("Close Button").GetComponent<Button>();
        closeButton.onClick.AddListener(() => {
            HideInventory();
            AudioRegistry.Play("sfx100v2_wood_04");
        });
        useButton = inventoryParent.Find("Use Button").GetComponent<Button>();
        dropButton = inventoryParent.Find("Drop Button").GetComponent<Button>();
        itemName = inventoryParent.Find("Title Panel/Item Name").GetComponent<TMP_Text>();
        itemInfo = inventoryParent.Find("Info Panel/Item Info").GetComponent<TMP_Text>();
        cancelPlantingButton = GameController.instance.canvas.Find("Cancel Planting Button").GetComponent<Button>();
        cancelPlantingButton.onClick.AddListener(() => {
            CancelPlanting();
            AudioRegistry.Play("switch2");
        });
        cancelPlacementButton = GameController.instance.canvas.Find("Cancel Placement Button").GetComponent<Button>();
        cancelPlacementButton.onClick.AddListener(() => {
            CancelPlacement();
            AudioRegistry.Play("switch2");
        });
        cancelWateringButton = GameController.instance.canvas.Find("Cancel Watering Button").GetComponent<Button>();
        cancelWateringButton.onClick.AddListener(() => {
            StopWatering();
            AudioRegistry.Play("switch2");
        });
        HideInventory();
    }

    public void ShowInventory() {
        DeselectItem();
        GameController.instance.player.SortInventory();
        openButton.gameObject.SetActive(false);
        useButton.gameObject.SetActive(false);
        dropButton.gameObject.SetActive(false);
        inventoryParent.gameObject.SetActive(true);
        for(int i = 0; i < PlayerController.inventory.Count; i++) {
            Transform cell = Instantiate(inventoryCellPrefab, itemContainer);
            int cachedIndex = i;
            cell.GetComponent<Button>().onClick.AddListener(() => {
                SelectItem(cachedIndex);
                AudioRegistry.Play("switch2");
            });
            cell.GetChild(0).GetComponent<Image>().sprite = PlayerController.inventory[i].icon;
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
        AbstractInventoryItem item = PlayerController.inventory[index];
        itemName.text = item.name;
        itemInfo.text = item.description;
        useButton.enabled = item.canUse;
        useButton.gameObject.SetActive(item.canUse);
        useButton.onClick.RemoveAllListeners();
        if(item.canUse) {
            useButton.onClick.AddListener(() => {
                HideInventory();
                GameController.instance.player.UseItem(item);
                AudioRegistry.Play("switch2");
            });
        }
        dropButton.enabled = item.canDrop;
        dropButton.gameObject.SetActive(item.canDrop);
        dropButton.onClick.RemoveAllListeners();
        if(item.canDrop) {
            dropButton.onClick.AddListener(() => {
                HideInventory();
                GameController.instance.player.DropItem(item);
                AudioRegistry.Play("switch2");
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
        GameController.instance.player.currentlyPlanting = null;
    }

    public void StartPlacement(Placeable placeable, float gridSize) {
        openButton.gameObject.SetActive(false);
        cancelPlacementButton.gameObject.SetActive(true);
        GameController.instance.player.currentlyPlacing = Instantiate(placeable.placeablePrefab,
            GameController.instance.player.transform.position, placeable.placeablePrefab.rotation);
        GameController.instance.player.currentlyPlacingItem = placeable;
        GameController.instance.player.currentlyPlacing.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        GameController.instance.player.currentlyPlacing.GetComponent<Collider>().enabled = false;
        GameController.instance.player.placementGridSnapping = gridSize;
    }

    public void StartPlacement(Placeable placeable) {
        StartPlacement(placeable, -1.0f);
    }

    public void CompletePlacement() {
        cancelPlacementButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);
        if(GameController.instance.player.currentlyPlacingItem.isConsumed) {
            GameController.instance.player.RemoveItem(GameController.instance.player.currentlyPlacingItem);
        }
        GameController.instance.player.currentlyPlacing.gameObject.layer = 0;
        GameController.instance.player.currentlyPlacing.GetComponent<Collider>().enabled = true;
        GameController.instance.player.currentlyPlacing = null;
        GameController.instance.player.placementGridSnapping = -1.0f;
        AudioRegistry.Play("sfx100v2_misc_27");
    }

    public void CancelPlacement() {
        Destroy(GameController.instance.player.currentlyPlacing.gameObject);
        CompletePlacement();
    }

    public void StopWatering() {
        openButton.gameObject.SetActive(true);
        cancelWateringButton.gameObject.SetActive(false);
        GameController.instance.player.currentlyWatering = null;
    }
}
