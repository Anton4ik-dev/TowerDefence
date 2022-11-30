using BattleSystem.BattleSO;
using UnityEngine;

namespace BattleSystem.BattleActions
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BulletSO bulletSO;
        private GameObject _target;
        private int _enemyLayer;
        public void PutTarget(GameObject target, int enemyLayer)
        {
            _target = target;
            _enemyLayer = enemyLayer;
        }
        private void Update()
        {
            rb.MovePosition(_target.transform.position * bulletSO.Speed);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == _enemyLayer)
            {
                //damage enemy
            }
        }
    }
}
