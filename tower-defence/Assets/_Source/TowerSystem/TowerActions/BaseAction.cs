using UnityEngine.SceneManagement;

namespace TowerSystem.TowerActions
{
    public class BaseAction : TowerDefaultAction
    {
        protected override void DestroyTower()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        protected override void OnMouseEnter() { }
        protected override void OnMouseExit() { }
    }
}