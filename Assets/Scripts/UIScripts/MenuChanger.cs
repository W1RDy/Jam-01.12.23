using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] private LevelButton[] _levelButtons;

    private void Start()
    {
        var _lastAvailableLevelIndex = LevelManager.Instance.GetLastAvailableLevel().index;
        foreach (var _levelButton in _levelButtons)
        {
            if (_levelButton.LevelIndex > _lastAvailableLevelIndex) break;
            _levelButton.MakeAvailable();
        }
    }
}
