using BattleSystem.BattleActions;
using TowerSystem.TowerActions;
using UnityEngine;

namespace Services
{
    public static class SpawnerService
    {
        public static void SpawnTower(GameObject cell, GameObject towerPrefab)
        {
            GameObject newTower = DefaultSpawnTower(cell, towerPrefab);
            newTower.GetComponent<TowerDefaultAction>().Initialize(cell);
        }
        public static void SpawnTower(GameObject cell, GameObject towerPrefab, float hp)
        {
            GameObject newTower = DefaultSpawnTower(cell, towerPrefab);
            newTower.GetComponent<TowerDefaultAction>().Initialize(cell, hp);
        }
        public static void SpawnBullet(GameObject bullet, Vector3 spawnPos, Transform target, int enemyLayer)
        {
            GameObject newBullet = GameObject.Instantiate(bullet, spawnPos, Quaternion.identity);
            newBullet.GetComponent<Bullet>().PutTarget(target, enemyLayer);
        }
        private static GameObject DefaultSpawnTower(GameObject cell, GameObject towerPrefab)
        {
            Vector3 spawnPos = cell.transform.position;
            spawnPos.y += towerPrefab.transform.localScale.y / 100;

            GameObject newTower = GameObject.Instantiate(towerPrefab, spawnPos, Quaternion.identity);
            return newTower;
        }
    }
}