using UnityEngine;

namespace TowersSO
{
    public class Tower : ScriptableObject
    {
        public GameObject TowerPrefab;
        public float HP;
        public ResourceType ResourceForBuy;
        public int Cost;
    }
}