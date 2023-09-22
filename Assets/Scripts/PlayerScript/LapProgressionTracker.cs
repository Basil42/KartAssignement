using UnityEngine;

[RequireComponent(typeof(PlayerDataRefBroadcaster))]
public class LapProgressionTracker : MonoBehaviour, IPlayerDataReceiver
{
    private PlayerData _playerData;

    public void OnPlayerDataReady(PlayerData data)
    {
        _playerData = data;
    }
}