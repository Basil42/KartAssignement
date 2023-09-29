using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarAcceleration : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private List<Transform> drivingPatches;
    [SerializeField] private float maxAcceleration = 5f;
    private float _currentAccelerationInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    [UsedImplicitly]
    private void OnAccelerate(InputValue value)
    {
        _currentAccelerationInput =  value.Get<float>();
    }
    private void FixedUpdate()
    {
        //acceleration
        for (int i = 0; i < drivingPatches.Count; i++)
        {
            DrivePatchUpdate(drivingPatches[i]);
        }
    }
    private void DrivePatchUpdate(Transform drivingPatch)
    {
        Vector2 forward = drivingPatch.up;
        _rb.AddForceAtPosition(
            _currentAccelerationInput * maxAcceleration * forward,
            drivingPatch.position,
            ForceMode2D.Force);
    }
}