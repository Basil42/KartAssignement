using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


[RequireComponent(typeof(Rigidbody2D))]
public class CarPhysics : MonoBehaviour
{ 
    //single rigidbody idea, direction dependant grip and existence of VelocityAtPoint method from: https://www.youtube.com/watch?v=CdPYlj5uZeI&t=6s&ab_channel=ToyfulGames
    private Rigidbody2D _rb;
    [SerializeField] private List<Transform> contactPatches;//one per "tire"
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
        
    }

    private void PatchPhysicsUpdate(Transform frontContactTransform)
    {
        throw new NotImplementedException();
    }
}

public struct ContactPatches
{
    public Vector2 LocalPosition;
    public AnimationCurve DirectionalGripCurve; 
    public float LateralSpeedGripLimit;//beyond which grip is lost
}