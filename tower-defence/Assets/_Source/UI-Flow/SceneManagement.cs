using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIFlow
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField] private Image pausePanel;
        [SerializeField] private Image badEndPanel;
        [SerializeField] private Image goodEndPanel;
        private void Awake()
        {
            ContinueTime();
        }
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
            ContinueTime();
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
        public void LoadLevelSelector()
        {
            SceneManager.LoadScene(1);
        }
        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(2);
        }
        public void LoadSecondLevel()
        {
            SceneManager.LoadScene(3);
        }
        public void LoadThirdLevel()
        {
            SceneManager.LoadScene(4);
        }
        public void Pause()
        {
            pausePanel.gameObject.SetActive(true);
            StopTime();
        }
        public void Back()
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
        private void StopTime()
        {
            Time.timeScale = 0;
        }
        private void ContinueTime()
        {
            Time.timeScale = 1;
        }
    }
}