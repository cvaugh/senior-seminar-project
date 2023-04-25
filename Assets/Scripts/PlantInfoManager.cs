using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantInfoManager : MonoBehaviour {
    public float padding = 10.0f;
    private RectTransform canvas;
    private RectTransform plantInfoParent;
    private TMP_Text plantName;
    private Button closeButton;
    private RectTransform growthBar;
    private RectTransform moistureBar;
    private RectTransform harvestBar;
    private Button harvestButton;

    private PlantContainer focused;
    private Vector2 canvasOffset;
    private float xLimit;
    private float yLimit;

    void Start() {
        canvas = GameController.instance.canvas.GetComponent<RectTransform>();
        plantInfoParent = canvas.transform.Find("Plant Info Parent").GetComponent<RectTransform>();
        plantName = plantInfoParent.Find("Plant Name Panel/Plant Name").GetComponent<TMP_Text>();
        closeButton = plantInfoParent.Find("Close Button").GetComponent<Button>();
        growthBar = plantInfoParent.Find("Plant Info Panel/Growth Level/Bar").GetComponent<RectTransform>();
        moistureBar = plantInfoParent.Find("Plant Info Panel/Moisture Level/Bar").GetComponent<RectTransform>();
        harvestBar = plantInfoParent.Find("Plant Info Panel/Harvest Level/Bar").GetComponent<RectTransform>();
        harvestButton = plantInfoParent.Find("Plant Info Panel/Harvest Button").GetComponent<Button>();
        canvasOffset = canvas.sizeDelta / 2.0f;
        xLimit = plantInfoParent.sizeDelta.x;
        yLimit = (plantInfoParent.sizeDelta.y * 2.0f) / 3.0f;
        closeButton.onClick.AddListener(Hide);
        harvestButton.onClick.AddListener(Harvest);
        Hide();
    }

    void Update() {
        if(focused != null) {
            Vector2 vpos = Camera.main.WorldToViewportPoint(focused.transform.position);
            Vector2 cpos = new Vector2(vpos.x * canvas.sizeDelta.x, vpos.y * canvas.sizeDelta.y) - canvasOffset;
            plantInfoParent.localPosition = new Vector2(
                Mathf.Clamp(cpos.x, -xLimit + padding, xLimit - padding),
                Mathf.Clamp(cpos.y, -yLimit + padding, yLimit - padding)
            );
            growthBar.localScale = new Vector3((float) Math.Min(focused.plant.growth / (focused.plant.growthStageDuration
                * focused.plant.growthStages), 1.0), 1.0f, 1.0f);
            moistureBar.localScale = new Vector3(focused.GetMoisture(), 1.0f, 1.0f);
            harvestBar.localScale = new Vector3((float) Math.Min(Math.Max(focused.plant.growth - focused.plant.growthStageDuration
                * focused.plant.growthStages, 0.0) / focused.plant.harvestStageDuration, 1.0), 1.0f, 1.0f);
            harvestButton.interactable = focused.plant.CanHarvest();
        }
    }

    public void Show(PlantContainer container) {
        focused = container;
        plantInfoParent.gameObject.SetActive(true);
        plantName.text = container.plant.name;
    }

    public void Hide() {
        focused = null;
        plantInfoParent.gameObject.SetActive(false);
    }

    public void Harvest() {
        if(focused.plant.CanHarvest()) {
            if(focused.plant.Harvest()) {
                focused.RemovePlant();
            }
        }
    }
}
