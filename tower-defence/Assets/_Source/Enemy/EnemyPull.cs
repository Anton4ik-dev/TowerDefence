using System;
using System.Collections.Generic;
using _Source.Enemy.EnemySO;
using UnityEngine;

namespace _Source.Enemy.EnemyStates
{
    public class EnemyPull
    {
        private Dictionary<TypeEnemySo, List<GameObject>> _activeEnemies;
        private Dictionary<TypeEnemySo, List<GameObject>> _enemiesInPull;
        private List<TypeEnemySo> _typesEnemy;
        private SpawnerEnemy _spawnerEnemy;

        public EnemyPull(SpawnerEnemy spawnerEnemy)
        {
            _activeEnemies = new Dictionary<TypeEnemySo, List<GameObject>>();
            _enemiesInPull = new Dictionary<TypeEnemySo, List<GameObject>>();
            _typesEnemy = new List<TypeEnemySo>();
            _spawnerEnemy = spawnerEnemy;
        }

        public bool CheckEnemy(TypeEnemySo typeEnemy)
        {

            try
            {
                if (_enemiesInPull[typeEnemy].Count != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _enemiesInPull.Add(typeEnemy, new List<GameObject>());
                _activeEnemies.Add(typeEnemy, new List<GameObject>());
                _typesEnemy.Add(typeEnemy);
                return false;
            }
        }

        public void ActivateEnemy(Transform pos, TypeEnemySo typeEnemy)
        {
            var enemy = _enemiesInPull[typeEnemy][0];
            _activeEnemies[typeEnemy].Add(enemy);
            _enemiesInPull[typeEnemy].Remove(enemy);
            enemy.transform.position = pos.position + Vector3.up;
            enemy.SetActive(true);
        }

        public void AddNewEnemyInPull(GameObject enemy, TypeEnemySo typeEnemy)
        {
            _enemiesInPull[typeEnemy].Add(enemy);
            enemy.GetComponent<EnemyController>().SetEnemyPull(this);
            enemy.SetActive(false);
        }

        public void MoveEnemyToPull(GameObject enemy, TypeEnemySo typeEnemy)
        {
            // try
            // {
            //     _activeEnemies[typeEnemy].Remove(enemy);
            //     _enemiesInPull[typeEnemy].Add(enemy);
            //     bool finish = true;
            //     foreach (var typeEnemies  in _typesEnemy)
            //     {
            //         if (_activeEnemies[typeEnemies].Count != 0) finish = false;
            //     }
            //     if(finish) _spawnerEnemy.SpawnNextWave();
            // }
            // catch (Exception e)
            // {
            //     Debug.Log(e);
            // }
            _activeEnemies[typeEnemy].Remove(enemy);
            _enemiesInPull[typeEnemy].Add(enemy);
            bool finish = true;
            foreach (var typeEnemies  in _typesEnemy)
            {
                if (_activeEnemies[typeEnemies].Count != 0) finish = false;
            }
            if(finish) _spawnerEnemy.SpawnNextWave();
        }
    }
}