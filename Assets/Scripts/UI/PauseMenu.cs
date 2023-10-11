using System;
using LevelManagement;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;


namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private InputAction pauseAction;
        private void Awake()
        {
            Assert.IsNotNull(levelManager);
            pauseAction.performed += ProcessPauseAction;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            pauseAction.performed -= ProcessPauseAction;
        }

        private void ProcessPauseAction(InputAction.CallbackContext obj)
        {
            if(gameObject.activeSelf)Pause();
            else Resume();
        }

        public void Resume()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Pause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1.0f;
            levelManager.LoadMainMenu();
        }
    }
}
