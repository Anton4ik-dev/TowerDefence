using Services;
using TowerSystem.TowersSO;
using UnityEngine;

namespace EconomicSystem
{
    public class TowerShop : MonoBehaviour
    {
        [SerializeField] private MineSO mineSO;
        [SerializeField] private ShootingTowerSO shootingTowerSO;
        [SerializeField] private CellsView cellsView;
        [SerializeField] private TowerPositionChooser towerPositionChooser;
        [SerializeField] private LayerMask placedLayer;

        private TowerDefaultSO _buyingTower;

        public void BuyMine()
        {
            _buyingTower = mineSO;
            if (ResourceService.OnCheckResource.Invoke(_buyingTower.Cost, _buyingTower.ResourceForBuy))
            {
                EnableShop();
            }
        }
        public void BuyShootingTower()
        {
            _buyingTower = shootingTowerSO;
            if (ResourceService.OnCheckResource.Invoke(_buyingTower.Cost, _buyingTower.ResourceForBuy))
            {
                EnableShop();
            }
        }
        public void DisableShop()
        {
            towerPositionChooser.enabled = false;
            cellsView.UnHighlightCells();
        }
        public void BuyTower(GameObject cell)
        {
            SpawnerService.SpawnTower(cell, _buyingTower.TowerPrefab, placedLayer);
            ResourceService.OnTakeResource(_buyingTower.Cost, _buyingTower.ResourceForBuy);
            DisableShop();
        }
        private void EnableShop()
        {
            cellsView.HighlightCells();
            towerPositionChooser.enabled = true;
        }
    }
}