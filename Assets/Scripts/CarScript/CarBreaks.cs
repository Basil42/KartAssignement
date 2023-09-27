using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CarBreaks : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float breakingPower = 5f;
    private float _neutralDrag;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _neutralDrag = _rb.drag;
    }

    [UsedImplicitly]
    private void OnBreak(InputValue value)
    {
        _rb.drag = _neutralDrag + breakingPower * value.Get<float>();//inconsistent with the rest but I'm not set on a way to deal with this
    }
}