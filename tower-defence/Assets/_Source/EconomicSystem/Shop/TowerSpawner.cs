using UnityEngine;

namespace EconomicSystem
{
    public static class TowerSpawner
    {
        public static void SpawnTower(GameObject cell, GameObject towerPrefab, LayerMask placedLayer)
        {
            Vector3 spawnPos = cell.transform.position;
            spawnPos.y += towerPrefab.transform.localScale.y / 2 + cell.transform.localScale.y / 2;
            GameObject.Instantiate(towerPrefab, spawnPos, Quaternion.identity);
            cell.layer = (int)Mathf.Log(1f * placedLayer.value, 2f);
        }
    }
}