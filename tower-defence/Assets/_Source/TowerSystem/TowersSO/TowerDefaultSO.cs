using UnityEngine;

namespace TowerSystem.TowersSO
{
    [CreateAssetMenu(fileName = "TowerDefaultSO", menuName = "ScriptableObjects/TowerDefaultSO", order = 1)]
    public class TowerDefaultSO : ScriptableObject
    {
        [Header("Stats")]
        public float HP;
        public int Cost;

        [Header("OtherInfo")]
        public GameObject TowerPrefab;
        public ResourceType ResourceForBuy;
        public LayerMask layerAfterTowerDestroy;

    }
}