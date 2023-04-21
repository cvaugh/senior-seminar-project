using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUIManager : MonoBehaviour {
    public Transform shopCellPrefab;
    public Color colorCanAfford;
    public Color colorTooExpensive;
    public Color colorTransactionButton;
    public Color colorDisabled;

    private Transform shopParent;
    private Transform shopItemContainer;
    private Transform inventoryItemContainer;
    private Button closeButton;
    private Button transactionButton;
    private TMP_Text transactionButtonText;
    private TMP_Text itemName;
    private TMP_Text itemInfo;
    private TMP_Text balanceText;

    private ShopManager shop;

    void Start() {
        shopParent = GameController.instance.canvas.Find("Shop");
        shopItemContainer = shopParent.Find("Shop Scroll/Viewport/Shop Contents");
        inventoryItemContainer = shopParent.Find("Inventory Scroll/Viewport/Inventory Contents");
        closeButton = shopParent.Find("Close Button").GetComponent<Button>();
        closeButton.onClick.AddListener(Hide);
        transactionButton = shopParent.Find("Transaction Button").GetComponent<Button>();
        transactionButtonText = shopParent.Find("Transaction Button/Text").GetComponent<TMP_Text>();
        itemName = shopParent.Find("Item Name Panel/Item Name").GetComponent<TMP_Text>();
        itemInfo = shopParent.Find("Info Panel/Item Info").GetComponent<TMP_Text>();
        balanceText = shopParent.Find("Balance Panel/Text").GetComponent<TMP_Text>();
        Hide();
    }

    public void Show(ShopManager shop) {
        this.shop = shop;
        DeselectItem();
        GameController.instance.player.SortInventory();
        shopParent.gameObject.SetActive(true);
        balanceText.text = BalanceManager.Get().ToString() + " F";
        transactionButton.GetComponent<Image>().color = colorDisabled;
        for(int i = 0; i < GameController.instance.player.inventory.Count; i++) {
            Transform cell = Instantiate(shopCellPrefab, inventoryItemContainer);
            int cachedIndex = i;
            cell.GetComponent<Button>().onClick.AddListener(() => SelectItem(false, cachedIndex));
            cell.GetChild(0).GetComponent<Image>().sprite = GameController.instance.player.inventory[i].icon;
            cell.GetChild(2).GetComponent<TMP_Text>().text = GameController.instance.player.inventory[i].value.ToString() + " F";
        }
        for(int i = 0; i < shop.inventory.Count; i++) {
            Transform cell = Instantiate(shopCellPrefab, shopItemContainer);
            int cachedIndex = i;
            cell.GetComponent<Button>().onClick.AddListener(() => SelectItem(true, cachedIndex));
            cell.GetChild(0).GetComponent<Image>().sprite = shop.inventory[i].icon;
            cell.GetChild(1).GetComponent<Image>().color = BalanceManager.CanAfford(shop.inventory[i]) ? colorCanAfford : colorTooExpensive;
            cell.GetChild(2).GetComponent<TMP_Text>().text = shop.inventory[i].value.ToString() + " F";
        }
    }

    public void Hide() {
        shopParent.gameObject.SetActive(false);
        for(int i = inventoryItemContainer.childCount - 1; i >= 0; i--) {
            Destroy(inventoryItemContainer.GetChild(i).gameObject);
        }
        for(int i = shopItemContainer.childCount - 1; i >= 0; i--) {
            Destroy(shopItemContainer.GetChild(i).gameObject);
        }
    }

    public void Reload() {
        if(shopParent.gameObject.activeSelf) {
            Hide();
            Show(shop);
        }
    }

    public void SelectItem(bool fromShop, int index) {
        if(fromShop) {
            AbstractInventoryItem item = shop.inventory[index];
            itemName.text = item.name;
            itemInfo.text = item.description;
            transactionButtonText.text = "Buy";
            transactionButton.GetComponent<Image>().color = BalanceManager.CanAfford(item) ? colorTransactionButton : colorDisabled;
            if(BalanceManager.CanAfford(item)) {
                transactionButton.enabled = true;
                transactionButton.onClick.RemoveAllListeners();
                transactionButton.onClick.AddListener(() => {
                    BuyItem(item);
                });
            }
        } else {
            AbstractInventoryItem item = GameController.instance.player.inventory[index];
            itemName.text = item.name;
            itemInfo.text = item.description;
            transactionButtonText.text = "Sell";
            transactionButton.GetComponent<Image>().color = colorTransactionButton;
            transactionButton.enabled = true;
            transactionButton.onClick.RemoveAllListeners();
            transactionButton.onClick.AddListener(() => {
                SellItem(item);
            });
        }
    }

    private void BuyItem(AbstractInventoryItem item) {
        if(!BalanceManager.CanAfford(item.value)) return;
        BalanceManager.Withdraw(item.value);
        GameController.instance.player.AddItem(item);
    }

    private void SellItem(AbstractInventoryItem item) {
        BalanceManager.Deposit(item.value);
        GameController.instance.player.RemoveItem(item);
    }

    public void DeselectItem() {
        itemName.text = "";
        itemInfo.text = "";
        balanceText.text = "";
        transactionButton.enabled = false;
    }
}
