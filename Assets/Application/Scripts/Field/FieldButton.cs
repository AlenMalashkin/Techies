using System;
using UnityEngine;
using UnityEngine.UI;

public class FieldButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    public Button Button => _button;
    public bool IsMined = false;

    private Field _field;
    private Lifebar _lifebar;
    
    public void Init(Field field, Lifebar lifebar)
    {
        _field = field;
        _lifebar = lifebar;
    }

    private void Start()
    {
        if (IsMined)
        {
            //_button.image.color = Color.red; 
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!IsMined)
        {
            _button.image.color = Color.green;
            _field.UpdateFieldButtons();
        }
        else
        {
            Debug.Log("You are hit the TNT");
            _button.image.color = Color.red;
            _lifebar.TakeDamage(1);
        }
    }
}
