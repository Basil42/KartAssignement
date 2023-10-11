using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    [CreateAssetMenu]
    public class LevelManager : ScriptableObject//crude singleton, you'd want it injected instead of serialized everywhere
    {

        [SerializeField] private List<LevelData> levelList;
        public int CurrentLevelIndex { get; private set; }

        private void OnEnable()
        {
            CurrentLevelIndex = 0;
        }

        public void LoadNextLevel()
        {
            if (CurrentLevelIndex >= levelList.Count)
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                CurrentLevelIndex = 0;
                return;
            }
            
            SceneManager.LoadScene(levelList[CurrentLevelIndex++].SceneName, LoadSceneMode.Single);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            CurrentLevelIndex = 0;
        }
        public LevelData GetCurrentLevelData()
        {
            #if UNITY_EDITOR
            if (CurrentLevelIndex == 0)
            {
                Debug.LogWarning("invalid current level index, attempting to return first level");
                return levelList[0];
            }
            #endif
            return levelList[CurrentLevelIndex - 1];
        }

        
    }
}