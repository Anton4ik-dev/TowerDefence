using UnityEngine;

namespace TowersSO
{
    [CreateAssetMenu(fileName = "ShootingTowerSO", menuName = "ScriptableObjects/ShootingTowerSO", order = 1)]
    public class ShootingTowerSO : TowerDefaultSO
    {
        public float FireRate;
        public float Damage;
    }
}