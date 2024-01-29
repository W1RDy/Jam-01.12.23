using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowService : MonoBehaviour
{
    [SerializeField] private WindowConfig[] _windows;
    private Dictionary<WindowType, Window> _windowDictionary;

    private void Awake()
    {
        InitializeWindowDictionary();
    }

    private void InitializeWindowDictionary()
    {
        _windowDictionary = new Dictionary<WindowType, Window>();

        foreach (var window in _windows)
        {
            _windowDictionary[window.windowType] = window.window;
        }
    }

    public Window GetWindow(WindowType _windowType)
    {
        return _windowDictionary[_windowType];
    }
}

[Serializable]
public class WindowConfig
{
    public WindowType windowType;
    public Window window;
}

public enum WindowType
{
    LoseSuperEasyWindow,
    LoseDeath,
    Win
}
