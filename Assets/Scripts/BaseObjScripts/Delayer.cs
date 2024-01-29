using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Delayer
{
    public static IEnumerator DelayCoroutine(float _delay, Action _action)
    {
        yield return new WaitForSeconds(_delay);
        _action();
    }
}
