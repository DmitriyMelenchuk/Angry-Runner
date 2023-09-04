using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Coroutine _currentCoroutine;

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnMove()
    {
        _rigidbody2D.velocity = new Vector2(_speed, 0);
        transform.rotation = _maxRotation;
        _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        StartState(DelayRotation());
    }

    public void Init()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Move.performed += ctx => OnMove();

        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private IEnumerator DelayRotation()
    {
        while (transform.rotation.z >= _minRotationZ)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void StartState(IEnumerator state)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(state);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody2D.velocity = Vector2.zero;
    }
}

