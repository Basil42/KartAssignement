using System;
using track;
using UnityEngine;

[RequireComponent(typeof(PlayerDataRefBroadcaster),typeof(Collider2D))]
public class LapProgressionTracker : MonoBehaviour, IPlayerDataReceiver
{
    private PlayerData _playerData;
    private Checkpoint _currentCheckPoint;

    public void OnPlayerDataReady(PlayerData data)
    {
        _playerData = data;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.layer == 6))
        {
            var cp = other.GetComponent<Checkpoint>();
            _playerData.CurrentCheckPoint.Add(cp);
            return;
        }
        Debug.LogError("Unhandled trigger type", gameObject);
    }
}