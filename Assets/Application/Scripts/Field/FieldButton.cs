using UnityEngine;
using UnityEngine.UI;

public class FieldButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private AudioClip explosionClip;

    [SerializeField] private Sprite noobSprite;
    [SerializeField] private Sprite tntSprite;

    public Button Button => button;
    public bool IsMined = false;

    private Field _field;
    private Lifebar _lifebar;
    
    public void Init(Field field, Lifebar lifebar)
    {
        _field = field;
        _lifebar = lifebar;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!IsMined)
        {
            button.image.sprite = noobSprite;
            _field.UpdateFieldButtons();
        }
        else
        {
            button.image.sprite = tntSprite;
            _lifebar.TakeDamage(1);
        }
    }

    public void SetMineInvisible()
    {
        button.image.color = Color.white;
    }

    public void SetMineVisible()
    {
        if (IsMined)
        {
            button.image.color = Color.red;
        }
    }
}
