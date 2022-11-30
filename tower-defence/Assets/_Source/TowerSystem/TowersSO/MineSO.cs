using UnityEngine;

namespace TowerSystem.TowersSO
{
    [CreateAssetMenu(fileName = "MineSO", menuName = "ScriptableObjects/MineSO", order = 1)]
    public class MineSO : TowerDefaultSO
    {
        [Header("Stats")]
        public float ExtractionTime;
        public int MinedAmount;

        [Header("OtherInfo")]
        public ResourceType MinedResource;
    }
}