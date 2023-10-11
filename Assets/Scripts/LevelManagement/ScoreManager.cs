using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace LevelManagement
{
    public class ScoreManager : MonoBehaviour//Per scene singleton
    {
        [SerializeField] private LevelManager levelManager;
        public static event Action RaceFinished;

        private void Awake()
        {
            Assert.IsNotNull(levelManager);
        }

        private void OnEnable()
        {
            LapProgressionTracker.LapCompleted += OnLapCompleted;
        }

        private void OnDisable()
        {
            LapProgressionTracker.LapCompleted -= OnLapCompleted;
        }
        // ReSharper disable RedundantDefaultMemberInitializer
        private int _nextPlaceToFinish = 0;
        private bool _isRaceOver = false;
        // ReSharper restore RedundantDefaultMemberInitializer
        private void OnLapCompleted(PlayerData obj)
        {
            LevelData levelData = levelManager.GetCurrentLevelData();
            Assert.IsNotNull(levelData);
            if (_isRaceOver) return;
            if (obj.LapCount >= levelData.LapCount)//a player finished the level
            {
                _isRaceOver = _nextPlaceToFinish >= levelData.PointValues.Count || levelData.StopAfterFirstPlace;
                obj.Points += !_isRaceOver
                    ? levelData.PointValues[_nextPlaceToFinish++]
                    : levelData.PointValues[^1];
                if(levelData.StopAfterFirstPlace || _isRaceOver)RaceFinished?.Invoke();
            }
        }
    }
}