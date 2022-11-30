using BattleSystem.BattleActions;
using UnityEngine;

namespace Services
{
    public static class SpawnerService
    {
        public static void SpawnTower(GameObject cell, GameObject towerPrefab, LayerMask placedLayer)
        {
            Vector3 spawnPos = cell.transform.position;
            spawnPos.y += towerPrefab.transform.localScale.y / 2 + cell.transform.localScale.y / 2;
            GameObject.Instantiate(towerPrefab, spawnPos, Quaternion.identity);
            cell.layer = (int)Mathf.Log(placedLayer.value, 2);
        }
        public static void SpawnBullet(GameObject bullet, Vector3 spawnPos, GameObject target, int enemyLayer)
        {
            GameObject newBullet = GameObject.Instantiate(bullet, spawnPos, Quaternion.identity);
            newBullet.GetComponent<Bullet>().PutTarget(target, enemyLayer);
        }
    }
}