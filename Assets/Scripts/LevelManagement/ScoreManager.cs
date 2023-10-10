using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace LevelManagement
{
    public class ScoreManager : MonoBehaviour//Per scene singleton
    {
        public static event Action RaceFinished;
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
            LevelData levelData = LevelData.current;
            Assert.IsNotNull(levelData);
            if (_isRaceOver) return;
            if (obj.LapCount >= levelData.lapCount)//a player finished the level
            {
                _isRaceOver = _nextPlaceToFinish >= levelData.pointValues.Count || levelData.stopAfterFirstPlace;
                obj.Points += !_isRaceOver
                    ? levelData.pointValues[_nextPlaceToFinish++]
                    : levelData.pointValues[^1];
                if(levelData.stopAfterFirstPlace || _isRaceOver)RaceFinished?.Invoke();
            }
        }
    }
}