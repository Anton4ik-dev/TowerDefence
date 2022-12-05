using UnityEngine;

namespace _Source.Enemy.EnemySO
{
    [CreateAssetMenu(fileName = "EnemySo",  menuName = "ScriptableObjects/Enemy", order = 1)]
    public class TypeEnemySo : ScriptableObject
    {
        public float hp;
        public bool isAir;
        public float speedMove;
        public int chanceOfCoinDrop;
        public float damage;
        public float speedAttack;
        public float damageForBase;
    }
}
