using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Enemy.EnemySO;
using _Source.Enemy.EnemyStates;
using UIFlow;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Enemy
{
    public class SpawnerEnemy : MonoBehaviour
    {
        [SerializeField] private List<Transform> positionForSpawn;
        [SerializeField] private List<WaveEnemySo> wavesEnemies;
        [SerializeField] private SceneManagement sceneManagement;
        private EnemyPull _pull;
        private int _currentCountSpawn;
        private List<int> _currentCountEnemyInWave; 
        private int _currentWave;

        private void Start()
        {
            _pull = new EnemyPull(this);
            SpawnEnemy(wavesEnemies[0]);
        }

        public void SpawnNextWave()
        {
            if (_currentWave == wavesEnemies.Count - 1)
            {
                sceneManagement.GoodEnd();
                return;
            }
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
                _pull.AddNewTypeEnemy(parameter.enemy.GetComponent<ABaseEnemyAction>().GetTypeEnemy);
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
            var type = Random.Range(0, _currentCountEnemyInWave.Count-1);
            if (_currentCountEnemyInWave[type] == 0)
            {
                _currentCountEnemyInWave.Remove(type);
                DistributionOfEnemies();
            }
            var enemy = wavesEnemies[_currentWave].parametersEnemies[type].enemy;
            var controllerEnemy = enemy.GetComponent<ABaseEnemyAction>();
            if (_pull.CheckEnemy(controllerEnemy.GetTypeEnemy))
            {
                _pull.ActivateEnemy(positionForSpawn[place], controllerEnemy.GetTypeEnemy);
                _currentCountSpawn--;
                _currentCountEnemyInWave[type]--;
                StartCoroutine(WaitSpawnEnemy());
            }
            else
            {
                _pull.AddNewEnemyInPull(Instantiate(enemy), controllerEnemy.GetTypeEnemy);
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
