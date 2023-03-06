using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem {
    public string name;
    public string description;
    public bool canUse = true;
    public bool canDrop = true;
    public Transform prefab;
    public Sprite thumbnail;
    // TODO
}
