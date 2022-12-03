using EconomicSystem;
using TowerSystem.TowersSO;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem.TowerActions
{
    public class MineAction : TowerDefaultAction
    {
        [SerializeField] private Button oilAdderButton;

        private float _extractionTime;
        private MineSO _mineSO;

        private void AddOil()
        {
            SetExtractionTimer();
            EnableTimer();
            ResourceService.OnAddResource?.Invoke(_mineSO.MinedAmount, _mineSO.MinedResource);
        }
        private void SetExtractionTimer()
        {
            _extractionTime = _mineSO.ExtractionTime;
        }
        private void EnableTimer()
        {
            oilAdderButton.gameObject.SetActive(false);
            enabled = true;
        }
        private void DisableTimer()
        {
            oilAdderButton.gameObject.SetActive(true);
            enabled = false;
        }
        private void Start()
        {
            _mineSO = (MineSO)towerSO;
            oilAdderButton.onClick.AddListener(AddOil);
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