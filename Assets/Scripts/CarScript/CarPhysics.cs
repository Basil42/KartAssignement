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
    [SerializeField] private List<ContactPatch> contactPatches;//one per "tire"

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    
    private void FixedUpdate()
    {
        for (int i = 0; i < contactPatches.Count; i++)
        {
            PatchPhysicsUpdate(contactPatches[i]);
        }
        
    }
    private void PatchPhysicsUpdate(ContactPatch patch)
    {
        if (_rb.velocity.magnitude < 0.00001f) return;
        Vector2 right = patch.transform.right;
        var patchPosition = patch.transform.position;
        Vector2 patchVelocity = _rb.GetPointVelocity(patchPosition);
        Vector2 lateralSpeed = right * Vector2.Dot(patchVelocity,right);
        var transferRatio = patch.directionalGripCurve.Evaluate(lateralSpeed.magnitude / patchVelocity.magnitude);
        //using straight up mass here is incorrect but the illusion is good enough
        _rb.AddForceAtPosition(Vector2.ClampMagnitude(-lateralSpeed * (transferRatio * _rb.mass), patch.lateralSpeedGripLimit),patchPosition,ForceMode2D.Force);
        Debug.Log((-lateralSpeed * (transferRatio * _rb.mass)).magnitude);
    }
}
[Serializable]
public struct ContactPatch
{
    public Transform transform;
    public AnimationCurve directionalGripCurve; 
    public float lateralSpeedGripLimit;//beyond which grip is lost
}