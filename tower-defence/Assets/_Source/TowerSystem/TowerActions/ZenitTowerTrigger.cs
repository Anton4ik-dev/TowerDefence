using _Source.Enemy;
using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class ZenitTowerTrigger : ShootingTowerTrigger
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (_layerMask == other.gameObject.layer && other.gameObject.GetComponent<EnemyController>().GetTypeEnemy.isAir)
            {
                _tower.AddEnemy(other.gameObject);
            }
        }
        protected override void OnTriggerExit(Collider other)
        {
            if (_layerMask == other.gameObject.layer && other.gameObject.GetComponent<EnemyController>().GetTypeEnemy.isAir)
            {
                _tower.RemoveEnemy(other.gameObject);
            }
        }
    }
}
