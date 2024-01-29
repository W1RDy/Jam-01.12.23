using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour, IHealthable
{
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    private GameService _gameService;
    public float jumpForce;
    private IMovable _movable;
    private Animator _animator;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
        _movable.SetSpeed(_speed);
        _gameService = GameObject.Find("GameService").GetComponent<GameService>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int _damage)
    {
        _hp -= _damage;
        if (_hp <= 0)
        {
            _hp = 0;
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        _gameService.FinishGameByDeath();
    }

    public void ChangeState(State _state, bool _isActivateState)
    {
        _animator.SetBool(Enum.GetName(typeof(State), _state), _isActivateState);
    }
}

public enum State
{
    Run,
    Idle,
    Jump
}
