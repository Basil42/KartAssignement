using System.Collections.Generic;
using LevelManagement;
using track;
using UnityEngine.InputSystem;
public class PlayerData//This isn't ideal and should be safer being a scriptable object
{
     public PlayerInput PlayerInput;
     public int LapCount;
     public int Points;
     public int playerIndex { get; }

     public string controlScheme { get; }

     public PlayerData(int playerIndex, string controlScheme, PlayerInput input)
     {
          this.playerIndex = playerIndex;
          this.controlScheme = controlScheme;
          PlayerInput = input;
          LapCount = 0;
          Points = 0;
          ScoreManager.RaceFinished += OnRaceFinished;
     }

     ~PlayerData()
     {
          ScoreManager.RaceFinished -= OnRaceFinished;
     }
     private void OnRaceFinished()
     {
          LapCount = 0;
     }
}