using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class CarSteering : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Rigidbody2D frontContactRb;
    [FormerlySerializedAs("maxTurningPower")] [SerializeField] private float maxTurningForce = 90f;
    [SerializeField] private float turningPower = 10f;
    private float _currentTurningInput;
    [SerializeField] private float maxSteeringAngle = 45f;
    private const float SteeringAnglePadding = 0.1f;

    private void Awake()
    {
        Assert.IsNotNull(frontContactRb);
        _rb = GetComponent<Rigidbody2D>();
    }

    [UsedImplicitly]
    private void OnTurn(InputValue value)
    { 
        _currentTurningInput = value.Get<float>();
    }

    private void FixedUpdate()
    {
        //TODO: clamping and resetting to neutral, pad the allowed steering to avoid the hinge "launching" the car
        var contactRotation =  frontContactRb.rotation - (_currentTurningInput * maxTurningForce * Time.fixedDeltaTime);
        frontContactRb.MoveRotation(contactRotation);//this is of course a world rotation and is incorrect
    }
}