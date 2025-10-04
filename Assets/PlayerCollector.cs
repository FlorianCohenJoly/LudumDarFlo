using UnityEngine;

public class PlayerCollector : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Collectible")) {
            var wp = other.GetComponent<WordPickup>();
            if(wp!=null) InventoryManager.Instance.AddWord(wp.word);
            // Optionnel : afficher un popup coloré si rare (voir plus bas)
            Destroy(other.gameObject);
        }
    }
}
