using EconomicSystem;
using TowerSystem.TowersSO;
using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class MineAction : TowerDefaultAction
    {
        [SerializeField] private GameObject oilAdderButton;

        private float _extractionTime;
        private MineSO _mineSO;
        public void AddOil()
        {
            EnableTimer();
            ResourceService.OnAddResource?.Invoke(_mineSO.MinedAmount, _mineSO.MinedResource);
            SetExtractionTimer();
        }
        private void SetExtractionTimer()
        {
            _extractionTime = _mineSO.ExtractionTime;
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
        private void Start()
        {
            _mineSO = (MineSO)towerSO;
            SetExtractionTimer();
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