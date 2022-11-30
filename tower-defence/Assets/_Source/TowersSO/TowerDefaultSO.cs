using UnityEngine;

namespace TowersSO
{
    [CreateAssetMenu(fileName = "TowerDefaultSO", menuName = "ScriptableObjects/TowerDefaultSO", order = 1)]
    public class TowerDefaultSO : ScriptableObject
    {
        public GameObject TowerPrefab;
        public float HP;
        public ResourceType ResourceForBuy;
        public int Cost;
    }
}