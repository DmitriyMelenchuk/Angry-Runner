using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdAttack : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenAttack;

    private PlayerInput _playerInput;

    private void OnEnable()
    {
        Initialize(_template);
        _playerInput.Enable();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Attack.performed += ctx => OnAttack();
    }

    private void OnAttack()
    {
        if (TryGetObject(out GameObject gameObject))
        {
            SetObject(gameObject, transform.position);
            DisableObjectAbdroadScreen();          
        }
    }
    protected virtual void SetObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
        gameObject.transform.rotation = transform.rotation;
    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
