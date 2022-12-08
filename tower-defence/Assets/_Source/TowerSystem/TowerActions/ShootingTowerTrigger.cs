using _Source.Enemy;
using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class ShootingTowerTrigger : MonoBehaviour
    {
        protected ShootingTowerAction _tower;
        protected int _enemyLayerMask;
        public void Initialize(ShootingTowerAction tower, int mask)
        {
            _tower = tower;
            _enemyLayerMask = mask;
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (_enemyLayerMask == other.gameObject.layer && other.gameObject.GetComponent<ABaseEnemyAction>().GetTypeEnemy.isAir == false)
            {
                _tower.AddEnemy(other.gameObject);
            }
        }
        protected virtual void OnTriggerExit(Collider other)
        {
            if (_enemyLayerMask == other.gameObject.layer && other.gameObject.GetComponent<ABaseEnemyAction>().GetTypeEnemy.isAir == false)
            {
                _tower.RemoveEnemy(other.gameObject);
            }
        }
    }
}