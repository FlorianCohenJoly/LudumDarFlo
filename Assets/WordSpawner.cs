using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordSpawner : MonoBehaviour
{
    [Header("Prefab & Canvas")]
    public GameObject wordPrefab;
    public RectTransform canvasTransform;

    [Header("Mots & Spawn")]
    public List<string> wordList = new List<string>()
    {
        "lumière","ombre","rêve","silence","mémoire","pluie","vent","feuillage",
        "murmure","étoile","clairière","nuage","rivière","éclat","ciel","aube",
        "crépuscule","sérénité","mélodie","reflet"
    };
    public int numberOfWords = 20;
    public float spawnInterval = 0.1f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        int spawned = 0;
        while (spawned < numberOfWords)
        {
            SpawnOneWord();
            spawned++;
            if (spawnInterval > 0f)
                yield return new WaitForSeconds(spawnInterval);
            else
                yield return null;
        }
    }

    void SpawnOneWord()
    {
        GameObject newWord = Instantiate(wordPrefab, canvasTransform);
        RectTransform rt = newWord.GetComponent<RectTransform>();

        float x = Random.Range(-canvasTransform.rect.width / 2f, canvasTransform.rect.width / 2f);
        float y = Random.Range(-canvasTransform.rect.height / 2f, canvasTransform.rect.height / 2f);
        rt.anchoredPosition = new Vector2(x, y);

        WordPickup wpu = newWord.GetComponent<WordPickup>();
        if (wpu != null)
        {
            string randomWord = wordList[Random.Range(0, wordList.Count)];
            wpu.SetWord(randomWord);
        }
    }
}
