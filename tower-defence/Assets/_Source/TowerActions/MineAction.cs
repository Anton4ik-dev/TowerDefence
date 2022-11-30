using EconomicSystem;
using TowersSO;
using UnityEngine;

namespace TowerActions
{
    public class MineAction : TowerDefaultAction
    {
        [SerializeField] private GameObject oilAdderButton;

        private float _extractionTime;
        private MineSO mineSO;

        private void Start()
        {
            mineSO = (MineSO)towerSO;
            SetExtractionTimer();
        }
        public void AddOil()
        {
            EnableTimer();
            ResourceService.OnAddResource?.Invoke(mineSO.MinedAmount, mineSO.MinedResource);
            SetExtractionTimer();
        }
        private void SetExtractionTimer()
        {
            _extractionTime = mineSO.ExtractionTime;
        }
        private void EnableTimer()
        {
            oilAdderButton.SetActive(false);
            enabled = true;
        }
        private void DisableTimer()
        {
            oilAdderButton.SetActive(true);
            enabled = false;
        }
        private void Update()
        {
            if (_extractionTime > 0)
                _extractionTime -= Time.deltaTime;
            else
                DisableTimer();
        }
    }
}