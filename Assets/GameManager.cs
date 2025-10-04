using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI TimerText;
    public GameObject EndPanel;
    public TextMeshProUGUI EndPhraseText;

    [Header("Timer")]
    public float timeLimit = 60f; // secondes
    private float timeRemaining;

    [Header("Spawner & Poème")]
    public WordSpawner wordSpawner;
    public PhraseGeneratorPoem phraseGenerator;

    private bool gameEnded = false;

    void Start()
    {
        timeRemaining = timeLimit;
        EndPanel.SetActive(false);

        // Lance le spawn des mots
        if (wordSpawner != null)
            wordSpawner.StartCoroutine("SpawnLoop"); // si tu utilises la coroutine du spawner
    }

    void Update()
    {
        if (gameEnded) return;

        // Timer
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0f) timeRemaining = 0f;
        TimerText.text = FormatTime(timeRemaining);

        // Fin de partie
        if (timeRemaining <= 0f)
        {
            EndGame();
        }
    }

    string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60f);
        int seconds = Mathf.FloorToInt(t % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        gameEnded = true;
        EndPanel.SetActive(true);

        // Récupère les mots collectés
        var collectedWords = InventoryManager.Instance.collected;

        // Génère un poème
        string finalPoem = phraseGenerator.GeneratePoem(collectedWords);

        // Affiche le poème
        EndPhraseText.text = finalPoem;
    }
}
