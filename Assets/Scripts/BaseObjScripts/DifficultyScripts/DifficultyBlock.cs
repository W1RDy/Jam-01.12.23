using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyBlock : DifficultyObj
{
    private Trigger _trigger;
    private Rigidbody2D _rb;
    private Action FixRb;
    private Action UnfixRb;

    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
        SetTrigger();
        FixRb = () => _rb.isKinematic = true;
        UnfixRb = () => _rb.isKinematic = false;
    }

    private void SetTrigger()
    {
        _trigger = _currentPart.difficultyPart.GetComponentInChildren<Trigger>();
        _trigger.TriggerTurnOn += FixRb;
        _trigger.TriggerTurnOff += UnfixRb;
    }

    private void RemoveTrigger()
    {
        _trigger.TriggerTurnOn -= FixRb;
        _trigger.TriggerTurnOff -= UnfixRb;
    }

    public override void ChangeDifficulty(DifficultyType _difficultyType)
    {
        RemoveTrigger();
        base.ChangeDifficulty(_difficultyType);
        SetTrigger();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (_trigger) RemoveTrigger();
    }
}
