using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Enemy.EnemyStates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Enemy
{
    public class SpawnerEnemy : MonoBehaviour
    {
        [SerializeField] private List<Transform> positionForSpawn;
        [SerializeField] private GameObject enemy;
        [SerializeField] private float timeSpawn;
        private EnemyPull _pull;
        private int _currentCountSpawn;

        private void Start()
        {
            _pull = new EnemyPull(new List<GameObject>(), this);
            SpawnEnemy(5);
        }

        public void SpawnEnemy(int count)
        {
            _currentCountSpawn += count;
            РаспределениеВрагов();
        }
        private void РаспределениеВрагов()
        {
            if(_currentCountSpawn == 0) return;
            _currentCountSpawn--;
            var place = Random.Range(0, positionForSpawn.Count);
            if (_pull.ActivateEnemy(positionForSpawn[place]) == false)
            {
                _pull.AddNewEnemyInPull(Instantiate(enemy));
                _pull.ActivateEnemy(positionForSpawn[place]);
                StartCoroutine(WaitSpawnEnemy());
            }
        }

        private IEnumerator WaitSpawnEnemy()
        {
            yield return new WaitForSeconds(timeSpawn);
            РаспределениеВрагов();
        }
    }
}
