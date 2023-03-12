using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayCurrentLevel : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();

        _text.text = "Уровень: " + PlayerPrefs.GetInt("Level", 1);
    }
}
