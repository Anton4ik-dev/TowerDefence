using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIFlow
{
    public class SceneManagement : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
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
    }
}