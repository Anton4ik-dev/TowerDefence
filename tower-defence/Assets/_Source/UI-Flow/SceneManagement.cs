using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIFlow
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField] private Image pausePanel;
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
            ContinueTime();
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