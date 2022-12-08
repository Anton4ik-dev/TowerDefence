using _Source.Enemy;
using System.Collections.Generic;
using TowerSystem.TowersSO;
using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class BombAction : TowerDefaultAction
    {
        private BombSO _bombSO;
        private List<GameObject> _enemies;
        private int _enemyLayerMask;
        private float _explosionCountdown;
        public override void Initialize(GameObject cell)
        {
            _bombSO = (BombSO)towerSO;
            _enemyLayerMask = (int)Mathf.Log(_bombSO.EnemyLayer.value, 2);
            _explosionCountdown = _bombSO.ExplosionTime;
            _enemies = new List<GameObject>();
            _cell = cell;
        }
        private void AddEnemy(GameObject enemy)
        {
            if (!_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
            }
        }
        private void RemoveEnemy(GameObject enemy)
        {
            if (_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
            }
        }
        private void CheckExplosion()
        {
            if (_explosionCountdown <= 0f)
            {
                Explode();
            }
        }
        private void Explode()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].GetComponent<EnemyController>().GetDamage(_bombSO.Damage);
            }
            DestroyTower();
        }
        private void Update()
        {
            CheckExplosion();
            _explosionCountdown -= Time.deltaTime;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_enemyLayerMask == other.gameObject.layer)
            {
                AddEnemy(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (_enemyLayerMask == other.gameObject.layer)
            {
                RemoveEnemy(other.gameObject);
            }
        }
        protected override void OnMouseEnter() { }
        protected override void OnMouseExit() { }
        protected override void OnMouseDown() { }
    }
}