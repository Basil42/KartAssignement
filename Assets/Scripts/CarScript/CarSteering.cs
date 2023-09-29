using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class CarSteering : MonoBehaviour
{
    [SerializeField] private Transform frontContactRb;
    [FormerlySerializedAs("maxTurningPower")] [SerializeField] private float maxTurningForce = 90f;
    private float _currentTurningInput;
    [SerializeField] private float maxSteeringAngle = 45f;

    private void Awake()
    {
        Assert.IsNotNull(frontContactRb);
    }

    [UsedImplicitly]
    private void OnTurn(InputValue value)
    { 
        _currentTurningInput = value.Get<float>();
    }

    private void FixedUpdate()
    {

        frontContactRb.Rotate(new Vector3(0f, 0f, -(_currentTurningInput * maxTurningForce * Time.fixedDeltaTime)));
        var localRot = frontContactRb.localEulerAngles;
        //avoiding problems with euler angles
        if (localRot.z < 0f) localRot.z = 360 + localRot.z;
        localRot.z = localRot.z > 180f
            ? Mathf.Max(localRot.z, 360 - maxSteeringAngle)
            : Mathf.Min(localRot.z, maxSteeringAngle);
        frontContactRb.localEulerAngles = localRot;
    }
}