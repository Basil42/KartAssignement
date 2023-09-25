using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    // private CarControls _inputActions;
    private Rigidbody2D _rb;
    private bool _isPlayerControlled;
    public PlayerData OwningPlayer
    {
        get => _owningPlayer;
        set
        {
            if (_isPlayerControlled ) UnregisterInputListeners();//we're changing controller
            _owningPlayer = value;
            RegisterInputListeners();
            _isPlayerControlled = true;
        }
    }

    public void RemovePlayerControl()
    {
        UnregisterInputListeners();
        _isPlayerControlled = false;
    }
    private void UnregisterInputListeners()
    {
        if (_owningPlayer.PlayerInput == null) return;
        
    }

    private void RegisterInputListeners()
    {
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _neutralDrag = _rb.drag;
    }
    #region simple input handling

    [SerializeField] private float maxAcceleration = 5f;
    private float _currentAccelerationInput;
    [UsedImplicitly]
    private void OnAccelerate(InputValue value)
    {
        _currentAccelerationInput =  value.Get<float>();
    }

    private float _neutralDrag;
    [SerializeField] private float breakingPower = 5f;

    [UsedImplicitly]
    private void OnBreak(InputValue value)
    {
        _rb.drag = _neutralDrag + breakingPower * value.Get<float>();//inconsistent with the rest but I'm not set on a way to deal with this
    }

    [SerializeField] private float maxTurningPower = 5f;
    private float _currentTurningInput;
    [SerializeField] private PlayerData _owningPlayer;

    [UsedImplicitly]
    private void OnTurn(InputValue value)
    { 
        _currentTurningInput = value.Get<float>();
    }
    #endregion

    private void FixedUpdate()
    {
        _rb.AddRelativeForce(_currentAccelerationInput * maxAcceleration * Vector2.up);
        _rb.MoveRotation(_currentTurningInput * maxTurningPower);
    }
}