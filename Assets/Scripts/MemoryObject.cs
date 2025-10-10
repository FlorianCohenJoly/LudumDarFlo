using UnityEngine;

public class MemoryObject : MonoBehaviour
{
    public MemoryManager memoryManager;
    private bool hasInteracted = false;



    public void Interaction()
    {
        if (!hasInteracted && memoryManager != null)
        {
            hasInteracted = true;
            memoryManager.RegisterInteraction();
            // Ajoute ici des effets visuels ou sonores pour l'interaction
            Debug.Log($"{gameObject.name} a été interagi.");
        }
    }
}
