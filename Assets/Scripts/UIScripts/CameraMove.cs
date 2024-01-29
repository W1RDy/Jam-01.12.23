using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour, IMovable
{
    private Transform _target;
    private float _speed;
    private bool _isMoving;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_isMoving) Move();
    }

    public void Move()
    {
        if (_target)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.position.x, _target.position.y, -10), _speed);
        }
    }

    public void SetMovableState(bool isMove)
    {
        _isMoving = isMove;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
