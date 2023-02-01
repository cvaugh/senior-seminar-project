using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public List<InventoryItem> inventory = new List<InventoryItem>();

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SortInventory() {
        inventory.Sort((a, b) => a.name.CompareTo(b.name));
    }
}
