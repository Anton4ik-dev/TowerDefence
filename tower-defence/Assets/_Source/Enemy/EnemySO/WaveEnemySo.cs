using System.Collections.Generic;
using UnityEngine;

namespace _Source.Enemy.EnemySO
{
    [CreateAssetMenu(fileName = "WaveEnemy", menuName = "ScriptableObjects/WaveEnemies", order = 1)]
    public class WaveEnemySo : ScriptableObject
    {
        public List<ParametersWaveEnemy> parametersEnemies;
        public float timeSpawnEnemy;
    }
}
