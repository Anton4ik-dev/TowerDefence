using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Enemy.EnemySO;
using _Source.Enemy.EnemyStates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Enemy
{
    public class SpawnerEnemy : MonoBehaviour
    {
        [SerializeField] private List<Transform> positionForSpawn;
        [SerializeField] private List<WaveEnemySo> wavesEnemies;
        private EnemyPull _pull;
        private int _currentCountSpawn;
        private List<int> _currentCountEnemyInWave; 
        [SerializeField]private int _currentWave;

        private void Start()
        {
            _pull = new EnemyPull(this);
            SpawnEnemy(wavesEnemies[0]);
        }

        public void SpawnNextWave()
        {
            if(_currentWave == wavesEnemies.Count-1) return;
            _currentWave++;
            SpawnEnemy(wavesEnemies[_currentWave]);
        }

        private void SpawnEnemy(WaveEnemySo wave)
        {
            _currentCountEnemyInWave = new List<int>();
            foreach (var parameter in wave.parametersEnemies)
            {
                _currentCountEnemyInWave.Add(parameter.count);
                _currentCountSpawn += parameter.count;
            }
            DistributionOfEnemies();
        }
        private void DistributionOfEnemies()
        {
            if (_currentCountSpawn == 0)
            {
                return;
            }
            var place = Random.Range(0, positionForSpawn.Count);
            var type = Random.Range(0, _currentCountEnemyInWave.Count);
            if (_currentCountEnemyInWave[type] == 0)
            {
                _currentCountEnemyInWave.Remove(type);
                DistributionOfEnemies();
            }
            var enemy = wavesEnemies[_currentWave].parametersEnemies[type].enemy;
            var typeEnemy = enemy.GetComponent<EnemyController>().GetTypeEnemy;
            if (_pull.CheckEnemy(typeEnemy))
            {
                _pull.ActivateEnemy(positionForSpawn[place], typeEnemy);
                _currentCountSpawn--;
                _currentCountEnemyInWave[type]--;
                StartCoroutine(WaitSpawnEnemy());
            }
            else
            {
                _pull.AddNewEnemyInPull(Instantiate(enemy), typeEnemy);
                DistributionOfEnemies();
            }
        }
        private IEnumerator WaitSpawnEnemy()
        {
            yield return new WaitForSeconds(wavesEnemies[_currentWave].timeSpawnEnemy);
            DistributionOfEnemies();
        }
    }
}
