using UnityEngine;

namespace _Source.Enemy.EnemySO
{
    [CreateAssetMenu(fileName = "EnemySo",  menuName = "ScriptableObjects/Enemy", order = 1)]
    public class TypeEnemySo : ScriptableObject
    {
        public float speedMove;
        public float damage;
        public float speedAttack;
        public float damageForBase;
    }
}
