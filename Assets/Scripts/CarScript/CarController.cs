using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;


public class CarController : MonoBehaviour
{
    private PlayerData _owningPlayer;
    public PlayerData OwningPlayer
    {
        get => _owningPlayer;
        set => _owningPlayer = value;
    }
}