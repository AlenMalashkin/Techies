using System;
using UnityEngine;
using UnityEngine.UI;
using VavilichevGD.Utils.Timing;
using YG;
using Random = UnityEngine.Random;

public class Field : MonoBehaviour
{
    [SerializeField] private FieldButton buttonPrefab;
    [SerializeField] private float secondsToSetMinesInvisible = 3;

    private Lifebar _lifebar;
    private LevelUpscaler _levelUpscaler;
    private SyncedTimer _timer;
    
    private int _currentCol = 0;
    private FieldButton[,] _buttons;

    private void OnEnable()
    {
        _levelUpscaler = new LevelUpscaler();
        
        _timer = new SyncedTimer(TimerType.UpdateTick);

        _timer.TimerFinished += TurnOffMines;
    }

    private void OnDisable()
    {
        
        _timer.TimerFinished -= TurnOffMines;
    }

    private void Start()
    {
        GenerateNewField();
        
        TurnOnMines();
    }

    public void Init(Lifebar lifebar)
    {
        _lifebar = lifebar;
    }

    private void GenerateNewField()
    {
        _buttons = new FieldButton[_levelUpscaler.RowCount, _levelUpscaler.ColCount];
    
        for (int i = 0; i < _levelUpscaler.RowCount; i++) 
        {
            for (int j = 0; j < _levelUpscaler.ColCount; j++)
            {
                var button = Instantiate(buttonPrefab, transform);
                button.Init(this, _lifebar);
                _buttons[i, j] = button;
            }
        }
        
        for (int i = 0; i < _levelUpscaler.RowCount; i++) 
        {
            for (int j = 0; j < _levelUpscaler.ColCount; j++) 
            {
                _buttons[i, j].Button.interactable = false;
            }
        }
        
        PutMinesInFieldButtons();
        
        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable) 
    {
        for (int i = 0; i < _levelUpscaler.RowCount; i++) 
        {
            _buttons[i, _currentCol].Button.interactable = interactable;
        }
    }

    private void PutMinesInFieldButtons()
    {
        for (int i = 0; i < _levelUpscaler.ColCount; i++) 
        {
            for (int j = 0; j < _levelUpscaler.MineCount; j++)
            {
                _buttons[Random.Range(0, _levelUpscaler.RowCount), i].IsMined = true;
            }
        }
    }

    private void TurnOnMines()
    {
        _timer.Start(secondsToSetMinesInvisible);
                   
        for (int i = 0; i < _levelUpscaler.RowCount; i++)
        {
            for (int j = 0; j < _levelUpscaler.ColCount; j++)
            {
                _buttons[i, j].SetMineVisible();
            }
        } 
    }

    private void TurnOffMines()
    {
        for (int i = 0; i < _levelUpscaler.RowCount; i++)
        {
            for (int j = 0; j < _levelUpscaler.ColCount; j++)
            {
                _buttons[i, j].SetMineInvisible();
            }
        }
    }

    public void UpdateFieldButtons()
    {
        for (int i = 0; i < _levelUpscaler.RowCount; i++)
        {
            _buttons[i, _currentCol].Button.interactable = false;
        }

        if (_currentCol < _levelUpscaler.ColCount - 1)
        {
            SetButtonsInteractable(false);

            for (int i = 0; i < _levelUpscaler.RowCount; i++)
            {
                _buttons[i, _currentCol + 1].Button.interactable = true;
            }

            _currentCol += 1;
        }
        else
        {
            Debug.Log("You win");

            var level = PlayerPrefs.GetInt("Level", 1);
            level += 1;
            PlayerPrefs.SetInt("Level", level);
                
            SceneLoader.Instance.ReloadCurrentScene();
        }
    }
}
