using JetBrains.Annotations;
using UnityEngine;
public class PlayerDataRefBroadcaster : MonoBehaviour
{
    private PlayerData _data;

    public PlayerData Data
    {
        get => _data;
        set
        {
            _data = value;
            SendMessage("OnPlayerDataReady", _data);
        }
    }
    
}

public interface IPlayerDataReceiver
{
    [UsedImplicitly]//called through messages
    public void OnPlayerDataReady(PlayerData data);
}