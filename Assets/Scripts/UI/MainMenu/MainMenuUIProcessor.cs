using System;
using JetBrains.Annotations;
using LevelManagement;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

//Just a class to enforce order of execution of the button response
namespace UI.MainMenu
{
    public class MainMenuUIProcessor : MonoBehaviour
    {
        [SerializeField]private PlayerManager playerInitRef;
        [FormerlySerializedAs("_levelManagerRef")] [SerializeField] private LevelManager levelManagerRef;

        private void Awake()
        {
            Assert.IsNotNull(playerInitRef);
            Assert.IsNotNull(levelManagerRef);
        }

        public void Startup(int numberOfPlayers)
        {
            playerInitRef.InitializePlayers(numberOfPlayers);
            levelManagerRef.LoadNextLevel();
        }
    }
}
