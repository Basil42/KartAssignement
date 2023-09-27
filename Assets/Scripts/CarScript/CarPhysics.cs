using System;
using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class CarPhysics : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Rigidbody2D frontContact;
    private Transform _frontContactTransform;
    [SerializeField] private Rigidbody2D backContact;
    private Transform _backContactTransform;
    [SerializeField] private float maxAcceleration = 5f;
    private float _currentAccelerationInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(frontContact);
        _frontContactTransform = frontContact.transform;
        _backContactTransform = backContact.transform;
    }
    
    [UsedImplicitly]
    private void OnAccelerate(InputValue value)
    {
        _currentAccelerationInput =  value.Get<float>();
    }
    
    private void FixedUpdate()
    {
        
        FrontContactPhysicsUpdate();
        BackContactPhysicsUpdate();
    }
    
    [Tooltip("The maximum amount of speed the contact patch can transfer forward in a second")] 
    [SerializeField] private float gripForceLimit = 10f;//you could make this mass dependant 
    private void BackContactPhysicsUpdate()
    {
        var velocity = backContact.velocity;
        var orthogonalDirection = _backContactTransform.right;
        var orthogonalSpeed = Vector2.Dot(velocity,orthogonalDirection);
        var speedTransferredForward = Mathf.Clamp( orthogonalSpeed,-gripForceLimit,gripForceLimit);
        velocity += (Vector2)(-_backContactTransform.up) * (Mathf.Abs(speedTransferredForward) * Time.fixedDeltaTime) - (Vector2)orthogonalDirection * (speedTransferredForward * Time.fixedDeltaTime);
        backContact.velocity = velocity;//this change gets instantly "digested" by the heavier car body-
        //unhinged force based solution
        
        
    }

    private void FrontContactPhysicsUpdate()
    {
        //Default to grip regime
        var frontContactVelocity = frontContact.velocity;
        var frontContactForward = _frontContactTransform.up;
        frontContact.velocity = frontContactVelocity.magnitude * frontContactForward;//the physics system might not be able to resolve this
        //Mathf.Cos(Vector2.Angle(frontContactVelocity, frontContactForward)) *
        frontContact.AddForce(frontContactForward * (_currentAccelerationInput * maxAcceleration * Time.fixedDeltaTime));
    }
}