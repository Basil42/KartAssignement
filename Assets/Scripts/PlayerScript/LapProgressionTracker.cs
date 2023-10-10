using System;
using System.Collections.Generic;
using track;
using UnityEngine;

[RequireComponent(typeof(PlayerDataRefBroadcaster),typeof(Collider2D))]
public class LapProgressionTracker : MonoBehaviour, IPlayerDataReceiver, ICheckpointDataReceiver, IStartLineDataReceiver
{
    private PlayerData _playerData;
    private HashSet<Checkpoint> _passedCheckpoints = new HashSet<Checkpoint>();

    public void OnPlayerDataReady(PlayerData data)
    {
        _playerData = data;
    }

    

    public void OnCheckpointPassed(Checkpoint cp)
    {
        _passedCheckpoints.Add(cp);//if the cp is already in the set it will simply be ignored
    }

    public static event Action<PlayerData> LapCompleted;
    public void OnStartLinePassed(HashSet<Checkpoint> requiredCPs)
    {
        if (requiredCPs.SetEquals(_passedCheckpoints))
        {
            _playerData.LapCount++;
            _passedCheckpoints.Clear();
            LapCompleted?.Invoke(_playerData);
        }
        //the player passed the start line without passing all the checkpoints
        //we could have feedback depending on circumstances, ignoring it for this exercice
    }
}



