using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Enemy.EnemyStates
{
    public class EnemyPull
    {
        private List<GameObject> _activeEnemies;
        private List<GameObject> _enemiesInPull;

        public EnemyPull(List<GameObject> baseEnemies, SpawnerEnemy spawner)
        {
            _enemiesInPull = baseEnemies;
            _activeEnemies = new List<GameObject>();
        }

        public bool CheckEnemy()
        {
            if (_enemiesInPull.Count != 0)
            {
                return true;
            }

            return false;
        }

        public void ActivateEnemy(Transform pos)
        {
            var enemy = _enemiesInPull[0];
            _activeEnemies.Add(enemy);
            _enemiesInPull.Remove(enemy);
            enemy.transform.position = pos.position + Vector3.up;
            enemy.SetActive(true);
        }

        public void AddNewEnemyInPull(GameObject enemy)
        {
            _enemiesInPull.Add(enemy);
            enemy.GetComponent<EnemyController>().SetEnemyPull(this);
        }

        public void MoveEnemyToPull(GameObject enemy)
        {
            try
            {
                _activeEnemies.Remove(enemy);
                _enemiesInPull.Add(enemy);
            }
            catch (Exception e)
            {
                Debug.Log("Takogo vraga net");
            }
        }
    }
}