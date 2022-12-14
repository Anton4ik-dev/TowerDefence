using UnityEngine;

namespace TowerSystem.TowersSO
{
    [CreateAssetMenu(fileName = "ShootingTowerSO", menuName = "ScriptableObjects/ShootingTowerSO", order = 1)]
    public class ShootingTowerSO : TowerDefaultSO
    {
        [Header("Stats")]
        public float FireRate;

        [Header("BattleInfo")]
        public LayerMask EnemyLayer;
        public GameObject BulletPrefab;
    }
}