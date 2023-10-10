using System;
using track;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerDataRefBroadcaster))]
public class PlayerCarManager : MonoBehaviour, IPlayerDataReceiver
{
    public CarController ControlledCar { get; private set; }
    private PlayerData _playerData;
#if UNITY_EDITOR
    [SerializeField] private CarController defaultCar;
#endif

    private void SetCarAsControlled(CarController car)
    {
        ControlledCar = car;
        ControlledCar.GetComponent<PlayerDataRefBroadcaster>().Data = _playerData;
    }

    public void OnPlayerDataReady(PlayerData data)
    {
        _playerData = data;
        
#if UNITY_EDITOR
        try
        {
            SetCarAsControlled(Instantiate(defaultCar,
                CarSpawnPoint.SpawnPoints[data.playerIndex].position,
                quaternion.identity,
                this.transform)); //here you might specify a starting rotation depending on level
        }
        catch(ArgumentOutOfRangeException e)
        {
            Debug.LogException(e,this);
            SetCarAsControlled(Instantiate(defaultCar,
                transform));//attempting to fallback to arbitrary position
        }
        
#endif
    }
}