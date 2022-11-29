using EconomicSystem;
using TowersSO;
using UnityEngine;
using UnityEngine.UI;

namespace TowerActions
{
    public class MineAction : MonoBehaviour
    {
        [SerializeField] private MineSO mineSO;
        [SerializeField] private GameObject oilAdderButton;
        [SerializeField] private Slider sliderHP;

        private float _extractionTime;
        private float _hp;

        private void Start()
        {
            SetExtractionTimer();
            SetHP();
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
        private void SetHP()
        {
            _hp = mineSO.HP;
            sliderHP.maxValue = _hp;
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
        private void OnMouseEnter()
        {
            sliderHP.gameObject.SetActive(true);
            sliderHP.value = _hp;
        }
        private void OnMouseExit()
        {
            sliderHP.gameObject.SetActive(false);
        }
    }
}