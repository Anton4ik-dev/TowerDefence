using Services;
using TowerSystem.TowersSO;
using UnityEngine;

namespace EconomicSystem
{
    public class TowerShop : MonoBehaviour
    {
        [Header("SO")]
        [SerializeField] private MineSO mineSO;
        [SerializeField] private ShootingTowerSO shootingTowerSO;
        [SerializeField] private TowerDefaultSO fenceSO;
        [SerializeField] private ShootingTowerSO zenitTowerSO;
        [SerializeField] private BombSO bombSO;

        [Header("ShopComponents")]
        [SerializeField] private CellsView cellsView;
        [SerializeField] private TowerPositionChooser towerPositionChooser;
        [SerializeField] private Shovel shovel;

        private TowerDefaultSO _buyingTower;

        public void BuyMine()
        {
            _buyingTower = mineSO;
            CheckResources();
        }
        public void BuyShootingTower()
        {
            _buyingTower = shootingTowerSO;
            CheckResources();
        }
        public void BuyFence()
        {
            _buyingTower = fenceSO;
            CheckResources();
        }
        public void BuyZenitTower()
        {
            _buyingTower = zenitTowerSO;
            CheckResources();
        }
        public void BuyBomb()
        {
            _buyingTower = bombSO;
            CheckResources();
        }
        public void EnableShovel()
        {
            shovel.enabled = true;
        }
        public void DisableShovel()
        {
            shovel.enabled = false;
        }
        public void DisableShop()
        {
            towerPositionChooser.enabled = false;
            cellsView.UnHighlightCells();
        }
        public void BuyTower(GameObject cell)
        {
            SpawnerService.SpawnTower(cell, _buyingTower.TowerPrefab, _buyingTower.layerOnSpawn);
            ResourceService.OnTakeResource(_buyingTower.Cost, _buyingTower.ResourceForBuy);
            DisableShop();
        }
        private void EnableShop()
        {
            cellsView.HighlightCells();
            towerPositionChooser.enabled = true;
        }
        private void CheckResources()
        {
            if (ResourceService.OnCheckResource.Invoke(_buyingTower.Cost, _buyingTower.ResourceForBuy))
            {
                EnableShop();
            }
        }
    }
}