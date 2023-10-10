using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace LevelManagement
{
    public class LevelDataBroadcaster : MonoBehaviour//per scene singleton
    {
        [SerializeField] private LevelData levelData;

        private void Awake()
        {
            Assert.IsNotNull(levelData);
            LevelData.current = levelData;
        }
    }
}