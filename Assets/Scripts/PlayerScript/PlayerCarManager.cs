using System;
using LevelManagement;
using track;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerDataRefBroadcaster))]
public class PlayerCarManager : MonoBehaviour, IPlayerDataReceiver
{
    public CarController ControlledCar { get; private set; }
    private PlayerData _playerData;

    [SerializeField] private CarController defaultCar;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
    }

    private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SpawnCar();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
    }

    private void SetCarAsControlled(CarController car)
    {
        ControlledCar = car;
        ControlledCar.GetComponent<PlayerDataRefBroadcaster>().Data = _playerData;
    }

    public void OnPlayerDataReady(PlayerData data)
    {
        _playerData = data;
    }
    private void SpawnCar()
    {

        try
        {
            SetCarAsControlled(Instantiate(defaultCar,
                CarSpawnPoint.SpawnPoints[_playerData.playerIndex].position,
                quaternion.identity)); //here you might specify a starting rotation depending on level
        }
        catch(ArgumentOutOfRangeException e)
        {
            Debug.LogException(e,this);
            SetCarAsControlled(Instantiate(defaultCar));//attempting to fallback to arbitrary position
        }
        

    }
}