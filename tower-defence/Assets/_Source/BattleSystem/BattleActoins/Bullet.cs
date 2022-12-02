using _Source.Enemy;
using BattleSystem.BattleSO;
using TowerSystem.TowerActions;
using UnityEngine;

namespace BattleSystem.BattleActions
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletSO bulletSO;
        private ShootingTowerAction _tower;
        private Transform _target;
        private LayerMask _enemyLayer;
        public void PutTarget(ShootingTowerAction tower, Transform target, LayerMask enemyLayer)
        {
            _tower = tower;
            _target = target;
            _enemyLayer = enemyLayer;
        }
        private void Update()
        {
            Vector3 dir = _target.position - transform.position;
            float distanceThisFrame = bulletSO.Speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if ((_enemyLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                collision.gameObject.GetComponent<EnemyController>().GetDamage(bulletSO.Damage);
                if (!_target.gameObject.activeSelf)
                    _tower.RemoveEnemy(_target.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
