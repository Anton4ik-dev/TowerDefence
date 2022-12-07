using BattleSystem.BattleActions;
using TowerSystem.TowerActions;
using UnityEngine;

namespace Services
{
    public static class SpawnerService
    {
        public static void SpawnTower(GameObject cell, GameObject towerPrefab, LayerMask placedLayer)
        {
            GameObject newTower = DefaultSpawnTower(cell, towerPrefab, placedLayer);
            newTower.GetComponent<TowerDefaultAction>().Initialize(cell);
        }
        public static void SpawnTower(GameObject cell, GameObject towerPrefab, LayerMask placedLayer, float hp)
        {
            GameObject newTower = DefaultSpawnTower(cell, towerPrefab, placedLayer);
            newTower.GetComponent<TowerDefaultAction>().Initialize(cell, hp);
        }
        public static void SpawnBullet(GameObject bullet, Vector3 spawnPos, Transform target, int enemyLayer)
        {
            GameObject newBullet = GameObject.Instantiate(bullet, spawnPos, Quaternion.identity);
            newBullet.GetComponent<Bullet>().PutTarget(target, enemyLayer);
        }
        private static GameObject DefaultSpawnTower(GameObject cell, GameObject towerPrefab, LayerMask placedLayer)
        {
            Vector3 spawnPos = cell.transform.position;
            spawnPos.y += towerPrefab.transform.localScale.y / 100;

            GameObject newTower = GameObject.Instantiate(towerPrefab, spawnPos, Quaternion.identity);

            cell.layer = (int)Mathf.Log(placedLayer.value, 2);
            return newTower;
        }
    }
}