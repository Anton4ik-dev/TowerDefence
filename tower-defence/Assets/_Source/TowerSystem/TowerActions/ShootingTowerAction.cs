using Services;
using System.Collections.Generic;
using System.Linq;
using TowerSystem.TowersSO;
using UnityEngine;

namespace TowerSystem.TowerActions
{
    public class ShootingTowerAction : TowerDefaultAction
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private ShootingTowerTrigger towerTrigger;

        private ShootingTowerSO _shootingTowerSO;
        private List<GameObject> _enemiesQueue;
        private GameObject _target = null;

        private int _layerMask;
        private float _fireCountdown;

        public void AddEnemy(GameObject enemy)
        {
            if(!_enemiesQueue.Contains(enemy))
            {
                _enemiesQueue.Add(enemy);
                UpdateNearestEnemy();
            }
        }
        public void RemoveEnemy(GameObject enemy)
        {
            if (_enemiesQueue.Contains(enemy))
            {
                _enemiesQueue.Remove(enemy);
                UpdateNearestEnemy();
            }
        }
        private void UpdateNearestEnemy()
        {
            if (_enemiesQueue.Count == 0)
            {
                _target = null;
                return;
            }
            _enemiesQueue = _enemiesQueue.OrderBy(enemy => (transform.position - enemy.transform.position).sqrMagnitude).ToList();
            _target = _enemiesQueue[0].gameObject;
        }
        private void CheckShot()
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = _shootingTowerSO.FireRate;
            }
        }
        private void Shoot()
        {
            SpawnerService.SpawnBullet(this, _shootingTowerSO.BulletPrefab, firePoint.position, _target.transform, _layerMask);
        }
        private void Start()
        {
            _shootingTowerSO = (ShootingTowerSO)towerSO;
            _enemiesQueue = new List<GameObject>();
            _layerMask = (int)Mathf.Log(_shootingTowerSO.EnemyLayer.value, 2);
            towerTrigger.Initialize(this, _layerMask);
        }
        private void Update()
        {
            if (_target != null && _target.gameObject.activeSelf)
            {
                CheckShot();
                _fireCountdown -= Time.deltaTime;
            }
            else
                RemoveEnemy(_target);
        }
    }
}