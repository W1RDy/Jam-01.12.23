using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour, IMovable
{
    private bool _isMove;
    private Vector2 _direction;
    private Rigidbody2D _rb;
    private float _speed;
    private Player _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (_isMove) Move();
    }

    public void Move()
    {
        _rb.velocity = new Vector2(_direction.x * _speed, _rb.velocity.y);
        Flip();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            _direction = direction;
            SetMovableState(true);
        }
        else
        {
            _direction = direction;
            SetMovableState(false);
        }
    }

    public Vector2 GetDirection() => _direction;

    public void SetMovableState(bool isMove)
    {
        _isMove = isMove;
        _player.ChangeState(State.Run, isMove);
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * _player.jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        if ((transform.localScale.x < 0 && _direction.x > 0) || (transform.localScale.x > 0 && _direction.x < 0))
            transform.localScale = new Vector2 (-1 * transform.localScale.x, transform.localScale.y);
    }
}
