using UnityEngine;

public class MemoryManager : MonoBehaviour
{
    [Header("Objets à interagir")]
    public GameObject[] interactableObjects; // Tes 4 objets souvenir
    private int interactedCount = 0;

    [Header("Objet final à faire apparaître")]
    public GameObject finalObjectPrefab; // Le 5e objet à instancier
    public Transform spawnPoint; // L’endroit où il apparaîtra

    private bool finalSpawned = false;

    // Appelé par les objets lorsqu'ils sont activés / interagis
    public void RegisterInteraction()
    {
        interactedCount++;

        if (interactedCount >= interactableObjects.Length && !finalSpawned)
        {
            SpawnFinalObject();
        }
    }

    void SpawnFinalObject()
    {
        if (finalObjectPrefab != null && spawnPoint != null)
        {
            finalObjectPrefab.SetActive(true);
            finalSpawned = true;
        }
        else
        {
            Debug.LogWarning("Final object ou spawn point manquant !");
        }
    }
}
