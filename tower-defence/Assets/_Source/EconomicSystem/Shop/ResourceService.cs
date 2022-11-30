using System;
using TMPro;

namespace EconomicSystem
{
    public class ResourceService
    {
        public static Action<int, ResourceType> OnAddResource;
        public static Func<int, ResourceType, bool> OnTakeResource;

        private TextMeshProUGUI _goldText;
        private TextMeshProUGUI _oilText;

        private int _gold;
        private int _oil;
        public ResourceService(TextMeshProUGUI goldText, TextMeshProUGUI oilText, int gold, int oil)
        {
            _goldText = goldText;
            _oilText = oilText;
            _gold = gold;
            _oil = oil;
            UpdateTextView();
        }
        public void Bind()
        {
            OnAddResource += AddResource;
            OnTakeResource += TakeResource;
        }
        private void AddResource(int resourceAmount, ResourceType resourceType)
        {
            if (resourceType == ResourceType.Gold)
                _gold += resourceAmount;
            else if (resourceType == ResourceType.Oil)
                _oil += resourceAmount;

            UpdateTextView();
        }
        private bool TakeResource(int resourceAmount, ResourceType resourceType)
        {
            if (resourceType == ResourceType.Gold && _gold - resourceAmount >= 0)
            {
                _gold -= resourceAmount;
                UpdateTextView();
                return true;
            }
            else if (resourceType == ResourceType.Oil && _oil - resourceAmount >= 0)
            {
                _oil -= resourceAmount;
                UpdateTextView();
                return true;
            }

            return false;
        }
        private void UpdateTextView()
        {
            _goldText.text = _gold.ToString();
            _oilText.text = _oil.ToString();
        }
    }
}