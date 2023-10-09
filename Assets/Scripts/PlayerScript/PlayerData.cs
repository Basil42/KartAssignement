using System.Collections.Generic;
using track;
using UnityEngine.InputSystem;
public struct PlayerData
{
     private int _playerIndex;
     private string _controlScheme;
     public PlayerInput PlayerInput;
     public List<Checkpoint> CurrentCheckPoint;

     public int PlayerIndex => _playerIndex;
     public string ControlScheme => _controlScheme;

     public PlayerData(int playerIndex, string controlScheme, PlayerInput input)
     {
          _playerIndex = playerIndex;
          _controlScheme = controlScheme;
          PlayerInput = input;
          CurrentCheckPoint = new List<Checkpoint>();
     }
}