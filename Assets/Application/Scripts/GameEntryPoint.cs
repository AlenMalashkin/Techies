using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private Lifebar lifebar;
    [SerializeField] private Field field;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        
        field.Init(lifebar);
    }
}
