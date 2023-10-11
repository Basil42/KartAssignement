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
        [SerializeField] private Canvas pauseMenuUI;
        private void Awake()
        {
            Assert.IsNotNull(levelManager);
            Assert.IsNotNull(pauseMenuUI);
            pauseAction.performed += ProcessPauseAction;
            pauseMenuUI.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            pauseAction.performed -= ProcessPauseAction;
        }

        private void ProcessPauseAction(InputAction.CallbackContext obj)
        {
            Debug.Log("processing pause input");
            if(pauseMenuUI.gameObject.activeSelf)Pause();
            else Resume();
        }

        public void Resume()
        {
            pauseMenuUI.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Pause()
        {
            pauseMenuUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1.0f;
            levelManager.LoadMainMenu();
        }
    }
}
