using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isCanMove = true;
    private PlayerMove _plMove;
    private Player _player;
    private bool _isJumping = true;
    private List<Collider2D> _colliders; 
    private float _playerExtern;

    private void Awake()
    {
        _plMove = GetComponent<PlayerMove>();
        _player = GetComponent<Player>();
        _colliders = new List<Collider2D>();
        _playerExtern = GetComponent<BoxCollider2D>().bounds.extents.y;
    }

    private void Update()
    {
        if (isCanMove)
        {
            var _movingDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
            if (_movingDirection.x != _plMove.GetDirection().x)
            {
                _plMove.SetDirection(_movingDirection);
            }

            if (Input.GetKeyUp(KeyCode.Space) && !_isJumping)
            {
                _plMove.Jump();
            }

            if (Input.GetKeyUp(KeyCode.C)) DifficultyManager.Instance.ChangeDifficultyToEasier();
        }
        else if (_plMove.GetDirection() != Vector2.zero) _plMove.SetMovableState(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && transform.position.y >= collision.GetContact(collision.contacts.Length - 1).point.y + _playerExtern)
        {
            _colliders.Add(collision.collider);
            _isJumping = false;
            _player.ChangeState(State.Jump, false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (_colliders.Contains(collision.collider)) _colliders.Remove(collision.collider);
            if (_colliders.Count == 0)
            {
                _isJumping = true;
                _player.ChangeState(State.Jump, true);
            }
        }    
    }
}
