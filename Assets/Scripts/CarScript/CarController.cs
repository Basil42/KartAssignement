using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;


public class CarController : MonoBehaviour, IPlayerDataReceiver
{
    public PlayerData owningPlayer { get; private set; }

    public void OnPlayerDataReady(PlayerData data)
    {
        owningPlayer = data;
    }
}