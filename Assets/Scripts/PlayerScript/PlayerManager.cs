using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class PlayerManager : ScriptableObject//crude singleton, should be injected
{
        [SerializeField] private GameObject playerPrefab;

        public int PlayerCount { get; private set; }

        //I'd like to be able to get these as reference instead of strings, but it doesn't appear to be possible.
        [SerializeField] private string firstKeyboardPlayerScheme = "Player 1";
        [SerializeField] private string extraKeyboardPlayerScheme = "Player 2";
        //[SerializeField] private string extraPlayerScheme = "Gamepad";//this will be used for all other controller players 

        private List<PlayerInput> _activePlayersList = new();

        private void OnEnable()
        {
                _activePlayersList.Clear();//remove references from previous sessions, shouldn't be a problem in actual builds though
        }

        public void InitializePlayers(int playerCount)//TODO: Joining System 
        {
                while (_activePlayersList.Count != 0)
                {
                        var player = _activePlayersList[0];
                        _activePlayersList.RemoveAt(0);
                        Destroy(player.gameObject);
                }
                PlayerCount = playerCount;
                Assert.IsTrue(PlayerCount > 0);
                int playerIndex = 0;
                var player1 =  PlayerInput.Instantiate(playerPrefab, playerIndex, firstKeyboardPlayerScheme, -1, Keyboard.current);
                player1.GetComponent<PlayerDataRefBroadcaster>().Data =
                        new PlayerData(playerIndex, firstKeyboardPlayerScheme, player1);
                DontDestroyOnLoad(player1.gameObject);
                _activePlayersList.Add(player1);
                
                if (PlayerCount == 1) return;
                playerIndex++;
                var player2 = PlayerInput.Instantiate(playerPrefab, playerIndex, extraKeyboardPlayerScheme, -1, Keyboard.current);
                player2.GetComponent<PlayerDataRefBroadcaster>().Data =
                        new PlayerData(playerIndex, extraKeyboardPlayerScheme, player2);
                DontDestroyOnLoad(player2.gameObject);
                _activePlayersList.Add(player2);

        }
}