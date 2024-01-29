using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Camera _camera;
    private IMovable _movable;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _movable = GetComponent<IMovable>();
        _movable.SetSpeed(_speed);
        _movable.SetMovableState(true);
    }

    public Camera GetMainCamera() => _camera;
}
