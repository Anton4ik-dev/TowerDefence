using EconomicSystem;
using Services;
using TMPro;
using TowerSystem.TowersSO;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem.TowerActions
{
    public class TowerDefaultAction : MonoBehaviour
    {
        [Header("TowerInfo")]
        public TowerDefaultSO towerSO;
        [SerializeField] private string maxLevelText;

        [Header("TowerUI")]
        [SerializeField] private Slider sliderHP;
        [SerializeField] private Image towerBuyField;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private TextMeshProUGUI upgradeText;
        [SerializeField] private Button repairButton;
        [SerializeField] private TextMeshProUGUI repairText;

        protected GameObject _cell;
        private float _hp;

        public virtual void Initialize(GameObject cell)
        {
            HealOnFull();
            SetMaxHP();
            Bind(cell);
        }
        public void Initialize(GameObject cell, float hp)
        {
            _hp = hp + towerSO.HP / 2;
            if (_hp > towerSO.HP)
                _hp = towerSO.HP;
            SetMaxHP();
            Bind(cell);
        }
        public bool GetDamage(float damage)
        {
            _hp -= damage;
            SetHP();
            if (_hp <= 0)
            {
                DestroyTower();
                return true;
            }
            return false;
        }
        public virtual void DestroyTower()
        {
            Destroy(gameObject);
            ChangeCellLayer();
        }
        protected void SetMaxHP()
        {
            sliderHP.maxValue = towerSO.HP;
            SetHP();
        }
        protected void HealOnFull()
        {
            _hp = towerSO.HP;
        }
        private void SetHP()
        {
            sliderHP.value = _hp;
        }
        private void Bind(GameObject cell)
        {
            upgradeButton.onClick.AddListener(UpgradeTower);
            repairButton.onClick.AddListener(RepairTower);

            if (towerSO.UpgradeTowerDefaultSO != null)
                upgradeText.text = $"{towerSO.UpgradeTowerDefaultSO.Cost}";
            else
                upgradeText.text = maxLevelText;

            repairText.text = $"{towerSO.RepairCost}";

            _cell = cell;
        }
        private void UpgradeTower()
        {
            if(towerSO.UpgradeTowerDefaultSO != null)
            {
                if (ResourceService.OnCheckResource.Invoke(towerSO.UpgradeTowerDefaultSO.Cost, towerSO.UpgradeTowerDefaultSO.ResourceForBuy))
                {
                    Debug.Log("UPGRADE");
                    ResourceService.OnTakeResource?.Invoke(towerSO.UpgradeTowerDefaultSO.Cost, towerSO.UpgradeTowerDefaultSO.ResourceForBuy);
                    SpawnerService.SpawnTower(_cell, towerSO.UpgradeTowerDefaultSO.TowerPrefab, towerSO.layerOnSpawn, _hp);
                    DestroyTower();
                }
            }
        }
        private void RepairTower()
        {
            if (ResourceService.OnCheckResource.Invoke(towerSO.RepairCost, towerSO.ResourceForBuy) && _hp < towerSO.HP)
            {
                Debug.Log("REPAIR");
                ResourceService.OnTakeResource?.Invoke(towerSO.RepairCost, towerSO.ResourceForBuy);
                HealOnFull();
                SetHP();
            }
        }
        private void ChangeCellLayer()
        {
            _cell.layer = (int)Mathf.Log(towerSO.layerAfterTowerDestroy.value, 2);
        }
        protected virtual void OnMouseEnter()
        {
            sliderHP.gameObject.SetActive(true);
        }
        protected virtual void OnMouseExit()
        {
            sliderHP.gameObject.SetActive(false);
        }
        protected virtual void OnMouseDown()
        {
            towerBuyField.gameObject.SetActive(!towerBuyField.gameObject.activeSelf);
        }
    }
}