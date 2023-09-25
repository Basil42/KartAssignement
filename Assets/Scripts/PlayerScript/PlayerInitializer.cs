using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerInitializer : MonoBehaviour
{
        [SerializeField] private GameObject playerPrefab;
        [SerializeField]private int playerCount;
        //I'd like to be able to get these as reference instead of strings, but it doesn't appear to be possible.
        [FormerlySerializedAs("player1Scheme")] [SerializeField] private string firstKeyboardPlayerScheme = "Player1";
        [SerializeField] private string extraKeyboardPlayerScheme = "Player2";
        //[SerializeField] private string extraPlayerScheme = "Gamepad";//this will be used for all other controller players 
        private void Start()
        {
                InitializePlayers();//this will done after people join with devices
        }

        private void InitializePlayers()
        {
                Assert.IsTrue(playerCount > 0);
                int playerIndex = 0;
                var player1 =  PlayerInput.Instantiate(playerPrefab, playerIndex, firstKeyboardPlayerScheme, -1, Keyboard.current);
                player1.GetComponent<PlayerDataRefBroadcaster>().Data =
                        new PlayerData(playerIndex, firstKeyboardPlayerScheme, player1);
                playerIndex++;
                var player2 = PlayerInput.Instantiate(playerPrefab, 1, extraKeyboardPlayerScheme, -1, Keyboard.current);
                player2.GetComponent<PlayerDataRefBroadcaster>().Data =
                        new PlayerData(playerIndex, extraKeyboardPlayerScheme, player2);

        }
}