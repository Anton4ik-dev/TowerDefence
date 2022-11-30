using UnityEngine;

namespace BattleSystem.BattleSO
{
    [CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObjects/BulletSO", order = 1)]
    public class BulletSO : ScriptableObject
    {
        [Header("Stats")]
        public float Damage;
        public float Speed;
    }
}