using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class CarSteering : MonoBehaviour
{
    [FormerlySerializedAs("frontContactRb")] [SerializeField] private Transform frontContact;
    [FormerlySerializedAs("maxTurningPower")] [SerializeField] private float maxTurningForce = 90f;
    private float _currentTurningInput;
    [SerializeField] private float maxSteeringAngle = 45f;

    private void Awake()
    {
        Assert.IsNotNull(frontContact);
    }

    [UsedImplicitly]
    private void OnTurn(InputValue value)
    { 
        _currentTurningInput = value.Get<float>();
    }

    private void FixedUpdate()
    {
        
        frontContact.Rotate(new Vector3(0f, 0f, -(_currentTurningInput * maxTurningForce * Time.fixedDeltaTime)));
        
        var localRot = frontContact.localEulerAngles;
        
        //avoiding problems with euler angles
        if (localRot.z < 0f) localRot.z = 360 + localRot.z;
        localRot.z = localRot.z > 180f
            ? Mathf.Max(localRot.z, 360 - maxSteeringAngle)
            : Mathf.Min(localRot.z, maxSteeringAngle);
        frontContact.localEulerAngles = localRot;
    }
}