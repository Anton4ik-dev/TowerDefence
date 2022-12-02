using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class ShootingTowerTrigger : MonoBehaviour
    {
        private ShootingTowerAction _tower;
        private int _layerMask;
        public void Initialize(ShootingTowerAction tower, int mask)
        {
            _tower = tower;
            _layerMask = mask;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_layerMask == other.gameObject.layer)
            {
                _tower.AddEnemy(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (_layerMask == other.gameObject.layer)
                _tower.RemoveEnemy(other.gameObject);
        }
    }
}