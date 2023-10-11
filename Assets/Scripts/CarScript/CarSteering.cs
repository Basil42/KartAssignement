using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
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
        var targetAngle = -_currentTurningInput * maxSteeringAngle;
        var maxFrameRotationAngle = maxTurningForce * Time.fixedDeltaTime;
        var currentRotationAngle = frontContact.localEulerAngles.z;
        currentRotationAngle = currentRotationAngle > 180f ? currentRotationAngle - 360f : currentRotationAngle;
        var angleToRotate = targetAngle - currentRotationAngle;
        var turnRotation = Mathf.Clamp(angleToRotate,-maxFrameRotationAngle,maxFrameRotationAngle);
        frontContact.Rotate(new Vector3(0f, 0f, turnRotation));
        
        var localRot = frontContact.localEulerAngles;
        #if UNITY_EDITOR
        if (Mathf.Abs(currentRotationAngle) > maxSteeringAngle +0.1f)
        {
            Debug.LogError("forbidden rotation");
        }
        #endif
       
    }
}