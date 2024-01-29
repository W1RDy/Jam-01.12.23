using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelConfig[] _levels;

    public static LevelManager Instance;
    private Dictionary<int, LevelConfig> _levelsDictionary;
    private GameService _gameService;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeLevelsDictionary();
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(Instance);

        try { Instance._gameService = GameObject.Find("GameService").GetComponent<GameService>(); }
        catch { }
    }

    private void InitializeLevelsDictionary()
    {
        _levelsDictionary = new Dictionary<int, LevelConfig>();

        foreach (var _level in _levels)
        {
            _levelsDictionary[_level.index] = _level;
            if (_level.index <= int.Parse(DataManager.Instance.container._availableLevelIndex)) 
                _level.isAvailable = true;
        }
    }

    public LevelConfig GetLevel(int _index) => _levelsDictionary[_index];

    public void MakeNextLevelAvailable()
    {
        var _nextLevelIndex = _gameService.LevelIndex + 1;
        GetLevel(_nextLevelIndex).isAvailable = true;
        DataManager.Instance.container._availableLevelIndex = _nextLevelIndex.ToString();
        DataManager.Instance.SaveData();
    }

    public LevelConfig GetLastAvailableLevel()
    {
        LevelConfig _lastAvailableLevel = null;
        foreach (var _level in _levels)
        {
            if (!_level.isAvailable && _lastAvailableLevel == null) throw new ArgumentNullException("Levels isn't available!"); 
            else if (!_level.isAvailable) return _lastAvailableLevel;

            _lastAvailableLevel = _level;
        }
        return _lastAvailableLevel;
    }
}

[Serializable]
public class LevelConfig
{
    public int index;
    public bool isAvailable;
}
