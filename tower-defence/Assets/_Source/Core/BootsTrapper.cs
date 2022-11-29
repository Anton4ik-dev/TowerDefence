using EconomicSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class BootsTrapper : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private TextMeshProUGUI oilText;
        [SerializeField] private int gold;
        [SerializeField] private int oil;

        private ResourceService _resourceManager; 

        private void Awake()
        {
            _resourceManager = new ResourceService(goldText, oilText, gold, oil);

            _resourceManager.Bind();
        }
    }
}