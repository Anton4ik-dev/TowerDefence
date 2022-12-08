using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIFlow
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField] private Image badEndPanel;
        [SerializeField] private Image goodEndPanel;
        [SerializeField] private Image settings;
        [SerializeField] private Image pausePanel;
        [SerializeField] private Image levelSelector;
        [SerializeField] private Image tutorialWindow;
        private static bool isTutorial = true;
        private void Awake()
        {
            if(tutorialWindow != null)
            {
                if (isTutorial)
                {
                    StopTime();
                    tutorialWindow.gameObject.SetActive(true);
                    isTutorial = false;
                }
            }
        }
        
        public void Restart()
        {
            ContinueTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadNextLevel()
        {
            ContinueTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        public void LoadMainMenu()
        {
            ContinueTime();
            SceneManager.LoadScene(0);
        }
        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(1);
        }
        public void LoadSecondLevel()
        {
            SceneManager.LoadScene(2);
        }
        public void LoadThirdLevel()
        {
            SceneManager.LoadScene(3);
        }
        public void ToSettings()
        {
            settings.gameObject.SetActive(true);
        }
        public void FromSettings()
        {
            settings.gameObject.SetActive(false);
        }
        public void ToLevelSelector()
        {
            levelSelector.gameObject.SetActive(true);
        }
        public void FromLevelSelector()
        {
            levelSelector.gameObject.SetActive(false);
        }
        public void ToPause()
        {
            pausePanel.gameObject.SetActive(true);
            StopTime();
        }
        public void FromPause()
        {
            pausePanel.gameObject.SetActive(false);
            ContinueTime();
        }
        public void GoodEnd()
        {
            goodEndPanel.gameObject.SetActive(true);
            StopTime();
        }
        public void BadEnd()
        {
            badEndPanel.gameObject.SetActive(true);
            StopTime();
        }
        public void ContinueTime()
        {
            Time.timeScale = 1;
        }
        private void StopTime()
        {
            Time.timeScale = 0;
        }
    }
}