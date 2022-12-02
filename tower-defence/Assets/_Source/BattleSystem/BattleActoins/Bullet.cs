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
        private int _enemyLayer;
        public void PutTarget(ShootingTowerAction tower, Transform target, int enemyLayer)
        {
            _tower = tower;
            _target = target;
            _enemyLayer = enemyLayer;
        }
        private void Update()
        {
            if(!_target.gameObject.activeSelf)
                gameObject.SetActive(false);

            Vector3 dir = _target.position - transform.position;
            float distanceThisFrame = bulletSO.Speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_enemyLayer == other.gameObject.layer)
            {
                other.gameObject.GetComponent<EnemyController>().GetDamage(bulletSO.Damage);
                gameObject.SetActive(false);
            }
        }
    }
}
