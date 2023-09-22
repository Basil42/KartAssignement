using UnityEngine.InputSystem;
public struct PlayerData
{
     private int _playerIndex;
     private string _controlScheme;
     public PlayerInput PlayerInput;

     public int PlayerIndex => _playerIndex;
     public string ControlScheme => _controlScheme;

     public PlayerData(int playerIndex, string controlScheme, PlayerInput input)
     {
          _playerIndex = playerIndex;
          _controlScheme = controlScheme;
          PlayerInput = input;
     }
}