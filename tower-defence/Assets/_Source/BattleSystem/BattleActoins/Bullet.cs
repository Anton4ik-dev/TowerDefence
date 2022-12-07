using _Source.Enemy;
using BattleSystem.BattleSO;
using UnityEngine;

namespace BattleSystem.BattleActions
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletSO bulletSO;
        private Transform _target;
        private int _enemyLayer;
        private bool _isActive = true;
        public void PutTarget(Transform target, int enemyLayer)
        {
            _target = target;
            _enemyLayer = enemyLayer;
        }
        private void Update()
        {
            if (!_target.gameObject.activeSelf)
                Destroy(gameObject);

            Vector3 dir = _target.position - transform.position;
            float distanceThisFrame = bulletSO.Speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(_isActive == false) return;
            if (_enemyLayer == other.gameObject.layer)
            {
                _isActive = false;
                other.gameObject.GetComponent<EnemyController>().GetDamage(bulletSO.Damage);
                Destroy(gameObject);
            }
        }
    }
}
