using UnityEngine;
using System.Collections.Generic;

public class PhraseGeneratorPoem : MonoBehaviour
{
    [Header("Catégories de mots")]
    public List<string> nature = new List<string>() { "rivière", "nuage", "feuillage", "étoile", "clairière", "pluie", "vent" };
    public List<string> temps = new List<string>() { "aube", "crépuscule", "nuit", "jour" };
    public List<string> abstrait = new List<string>() { "mémoire", "silence", "rêve", "sérénité", "mélodie", "reflet", "éclat" };

    private string[] structures = new string[]
    {
        "Le {0} danse sous le {1} à l'{2}.",
        "Un {0} de {1} s'éveille à l'{2}.",
        "Entre {0} et {1}, {2} brille.",
        "{0} et {1} se rejoignent dans {2}.",
        "Le {0} murmure au {1} pendant l'{2}."
    };

    private string[] connectors = new string[] { "dans", "sous", "entre", "au-dessus de", "près de", "au cœur de" };

    public string GeneratePoem(List<string> collectedWords)
    {
        if (collectedWords == null || collectedWords.Count == 0)
            return "Aucun mot collecté.";

        List<string> chosenNature = FilterWords(collectedWords, nature);
        List<string> chosenTemps = FilterWords(collectedWords, temps);
        List<string> chosenAbstrait = FilterWords(collectedWords, abstrait);

        Shuffle(chosenNature);
        Shuffle(chosenTemps);
        Shuffle(chosenAbstrait);

        List<string> poemLines = new List<string>();
        int lines = Mathf.Min(collectedWords.Count / 3, 5); // 1 ligne pour 3 mots max 5 lignes
        if (lines == 0) lines = 1;

        for (int i = 0; i < lines; i++)
        {
            string structure = structures[Random.Range(0, structures.Length)];

            string word0 = chosenNature.Count > 0 ? GetWord(chosenNature) : GetWord(chosenAbstrait);
            string word1 = chosenAbstrait.Count > 0 ? GetWord(chosenAbstrait) : GetWord(chosenNature);
            string word2 = chosenTemps.Count > 0 ? GetWord(chosenTemps) : GetWord(chosenAbstrait);

            string connector = connectors[Random.Range(0, connectors.Length)];
            string line = structure.Replace("{0}", word0)
                                   .Replace("{1}", word1 + " " + connector)
                                   .Replace("{2}", word2);

            poemLines.Add(line);
        }

        return string.Join("\n", poemLines);
    }

    private List<string> FilterWords(List<string> collected, List<string> category)
    {
        List<string> filtered = new List<string>();
        foreach (var w in collected)
        {
            if (category.Contains(w) && !filtered.Contains(w))
                filtered.Add(w);
        }
        return filtered;
    }

    private string GetWord(List<string> list)
    {
        if (list.Count == 0) return "…";
        string word = list[0];
        list.RemoveAt(0);
        return word;
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            string tmp = list[i];
            list[i] = list[r];
            list[r] = tmp;
        }
    }
}
