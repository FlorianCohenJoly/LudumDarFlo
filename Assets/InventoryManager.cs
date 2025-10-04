using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InventoryManager : MonoBehaviour {
    public static InventoryManager Instance;
    public int capacity = 7;
    public List<string> collected = new List<string>();
    public TextMeshProUGUI inventoryText;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddWord(string w) {
        if (collected.Count >= capacity) collected.RemoveAt(0);
        collected.Add(w);
        RefreshUI();
    }

    void RefreshUI() {
        if(inventoryText != null)
            inventoryText.text = "Collection :\n" + string.Join(", ", collected);
    }
}
