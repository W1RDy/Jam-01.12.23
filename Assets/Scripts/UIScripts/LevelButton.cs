using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private ButtonService _buttonService;
    [SerializeField] private Image _lock;
    [SerializeField] private Button _button;
    private Text _levelText;
    public int LevelIndex {get => _levelIndex;}

    private void Awake()
    {
        _levelText = GetComponentInChildren<Text>();
        _levelText.text = _levelIndex.ToString();
    }

    public void LoadLevel()
    {
        _buttonService.LoadLevel(_levelIndex);
    }

    public void MakeAvailable()
    {
        GetComponent<Image>().color = Color.white;
        _lock.enabled = false;
        _button.interactable = true;
    }
}
