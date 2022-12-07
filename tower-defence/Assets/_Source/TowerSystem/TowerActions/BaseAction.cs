using UIFlow;
using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class BaseAction : TowerDefaultAction
    {
        [SerializeField] private SceneManagement sceneManagement;
        private void Start()
        {
            HealOnFull();
            SetMaxHP();
        }
        public override void DestroyTower()
        {
            sceneManagement.BadEnd();
        }
        protected override void OnMouseEnter() { }
        protected override void OnMouseExit() { }
        protected override void OnMouseDown() { }
    }
}