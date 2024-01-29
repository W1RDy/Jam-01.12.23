using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowActivator : MonoBehaviour
{
    [SerializeField] WindowService _windowService;

    public void ActivateWindow(WindowType _windowType)
    {
        var _window = _windowService.GetWindow(_windowType);
        _window.gameObject.SetActive(true);
    }

    public void DeactivateWindow(WindowType _windowType)
    {
        var _window = _windowService.GetWindow(_windowType);
        _window.gameObject.SetActive(false);
    }
}
