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
        car.OwningPlayer = _playerData;
    }

    public void OnPlayerDataReady(PlayerData data)
    {
        _playerData = data;
#if UNITY_EDITOR
        SetCarAsControlled(Instantiate(defaultCar,transform));
#endif
    }
}