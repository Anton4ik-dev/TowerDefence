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
        private ShootingTowerSO _shootingTowerSO;
        private List<Collider> _enemiesQueue;
        private GameObject _target = null;

        private int _layerMask;
        private float _fireCountdown;

        //call this method on triggerEnter and TriggerExit
        public void UpdateNearestEnemy()
        {
            var colliders = Physics.OverlapSphere(transform.position, _shootingTowerSO.Radious, _layerMask);
            _enemiesQueue = colliders.OrderBy(enemy => (transform.position - enemy.transform.position).sqrMagnitude).ToList();
            if(_enemiesQueue.Count == 0)
            {
                _target = null;
                return;
            }
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
            SpawnerService.SpawnBullet(this, _shootingTowerSO.BulletPrefab, firePoint.position, _target, _layerMask);
        }
        private void Start()
        {
            _shootingTowerSO = (ShootingTowerSO)towerSO;
            _enemiesQueue = new List<Collider>();
            _layerMask = 1 << (int)Mathf.Log(_shootingTowerSO.EnemyLayer.value, 2);
        }
        private void Update()
        {
            if (_target != null)
            {
                CheckShot();
                _fireCountdown -= Time.deltaTime;
            }
        }
    }
}