using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordPickup : MonoBehaviour
{
    public string word;
    private bool isRare = false;

    private TextMeshProUGUI tmp;
    private Button button;

    void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();

        if (button != null)
            button.onClick.AddListener(OnClick);
    }

    public void SetWord(string newWord, bool rare = false)
    {
        word = newWord;
        isRare = rare;

        if (tmp != null)
        {
            tmp.text = word;
            tmp.color = isRare ? Color.yellow : Color.white;
        }
    }

    void OnClick()
    {
        InventoryManager.Instance.AddWord(word);
        Destroy(gameObject);
    }
}
