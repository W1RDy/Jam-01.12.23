using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DifficultyManager : MonoBehaviour
{
    public event Action<DifficultyType> ChangeDifficulty;

    public static DifficultyManager Instance;
    private DifficultyType _currentDifficulty;
    private GameService _gameService;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);
        Instance._gameService = GameObject.Find("GameService").GetComponent<GameService>();
        Instance._currentDifficulty = DifficultyType.Hard;
    }

    public void ChangeDifficultyToEasier()
    {
        var _difficultyIndex = (int)_currentDifficulty + 1;
        if (_difficultyIndex <= (int)DifficultyType.Easy)
        {
            _currentDifficulty = (DifficultyType)_difficultyIndex;
            ChangeDifficulty?.Invoke(_currentDifficulty);
        }
        else _gameService.FinishGameBySuperEasy();

    }
}
