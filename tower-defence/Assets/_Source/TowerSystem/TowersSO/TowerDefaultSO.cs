using UnityEngine;

namespace TowerSystem.TowersSO
{
    [CreateAssetMenu(fileName = "TowerDefaultSO", menuName = "ScriptableObjects/TowerDefaultSO", order = 1)]
    public class TowerDefaultSO : ScriptableObject
    {
        [Header("Stats")]
        public float HP;
        public int Cost;

        [Header("TowerDefaultInfo")]
        public GameObject TowerPrefab;
        public ResourceType ResourceForBuy;
        public LayerMask layerAfterTowerDestroy;
        public LayerMask layerOnSpawn;

        [Header("UpgradeTowerInfo")]
        public TowerDefaultSO UpgradeTowerDefaultSO;

        [Header("RepairCost")]
        public int RepairCost;

    }
}