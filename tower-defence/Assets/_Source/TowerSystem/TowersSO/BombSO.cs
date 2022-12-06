using UnityEngine;

namespace TowerSystem.TowersSO
{
    [CreateAssetMenu(fileName = "BombSO", menuName = "ScriptableObjects/BombSO", order = 1)]
    public class BombSO : TowerDefaultSO
    {
        [Header("Stats")]
        public float ExplosionTime;
        public float Damage;

        [Header("OtherInfo")]
        public LayerMask EnemyLayer;
    }
}