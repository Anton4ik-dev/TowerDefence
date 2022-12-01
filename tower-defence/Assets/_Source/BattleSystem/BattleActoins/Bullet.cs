using _Source.Enemy;
using _Source.Enemy.EnemyStates;
using BattleSystem.BattleSO;
using TowerSystem.TowerActions;
using UnityEngine;

namespace BattleSystem.BattleActions
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BulletSO bulletSO;
        public ShootingTowerAction tower;
        public Transform target;
        private LayerMask _enemyLayer;
        public void PutTarget(ShootingTowerAction tower, Transform target, LayerMask enemyLayer)
        {
            this.tower = tower;
            this.target = target;
            _enemyLayer = enemyLayer;
        }
        private void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = bulletSO.Speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if ((_enemyLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                collision.gameObject.GetComponent<EnemyController>().GetDamage(bulletSO.Damage, this);
            }
        }
    }
}
