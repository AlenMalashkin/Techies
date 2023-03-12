using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(LoadNewScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadNewScene);   
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
