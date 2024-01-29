using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private WindowActivator _windowActivator;
    [SerializeField] private Trigger _trigger;
    public int LevelIndex { get => _levelIndex; }

    private void Awake()
    {
        _trigger.TriggerTurnOn += FinishByWin;
    }

    public void FinishGameBySuperEasy()
    {
        FinishGame();
        _windowActivator.ActivateWindow(WindowType.LoseSuperEasyWindow);
    }

    public void FinishGameByDeath()
    {
        FinishGame();
        _windowActivator.ActivateWindow(WindowType.LoseDeath);
    }

    public void FinishByWin()
    {
        LevelManager.Instance.MakeNextLevelAvailable();
        FinishGame();
        _windowActivator.ActivateWindow(WindowType.Win);
    }

    private void FinishGame()
    {
        _playerController.isCanMove = false;
    }

    private void OnDestroy()
    {
        _trigger.TriggerTurnOn -= FinishByWin;
    }
}
