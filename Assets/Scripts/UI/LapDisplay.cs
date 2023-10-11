using LevelManagement;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LapDisplay : MonoBehaviour
    {
        private TMP_Text _display;
        [SerializeField] private LevelManager levelManager;
        
        private void Awake()
        {
            _display = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _display.text = $"lap : {_currentLap}/{levelManager.GetCurrentLevelData().LapCount}";

        }

        private void OnEnable()
        {
            LapProgressionTracker.LapCompleted += OnLapCompleted;
        }

        private void OnDisable()
        {
            LapProgressionTracker.LapCompleted -= OnLapCompleted;
        }

        

        private int _currentLap = 1;
        
        private void OnLapCompleted(PlayerData obj)
        {
            if (obj.LapCount >= _currentLap)
            {
                _display.text = $"{++_currentLap}/{levelManager.GetCurrentLevelData().LapCount}";
            }
        }
    }
}