using UnityEngine;

namespace TowersSO
{
    [CreateAssetMenu(fileName = "MineSO", menuName = "ScriptableObjects/MineSO", order = 1)]
    public class MineSO : TowerDefaultSO
    {
        public float ExtractionTime;
        public int MinedAmount;
        public ResourceType MinedResource;
    }
}