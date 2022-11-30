using System.Collections;
using System.Collections.Generic;
using TowersSO;
using UnityEngine;

namespace TowerActions
{
    public class ShootingTowerAction : TowerDefaultAction
    {
        private ShootingTowerSO shootingTowerSO;

        private void Start()
        {
            shootingTowerSO = (ShootingTowerSO)towerSO;
        }
        private void Update()
        {
            
        }
    }
}