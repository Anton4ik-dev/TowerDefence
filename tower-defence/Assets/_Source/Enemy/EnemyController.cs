using System.Collections;
using _Source.EconomicSystem;
using _Source.Enemy.EnemySO;
using _Source.Enemy.EnemyStates;
using TowerSystem.TowerActions;
using Random = UnityEngine.Random;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemyController : MonoBehaviour, IBaseEnemyAction
    {
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private TypeEnemySo typeEnemy;
        [SerializeField] private Vector3 vectorMoving;
        [SerializeField] private LayerMask layerTower;
        [SerializeField] private LayerMask layerBase;
        public TypeEnemySo GetTypeEnemy => typeEnemy;
        private EnemyStateMachine _stateMachine;
        private bool _isMoving = true;
        private float _currentHp;
        private EnemyPull _pull;

        private void Awake()
        {
            _stateMachine = new EnemyStateMachine(GetComponent<Rigidbody>(), typeEnemy, vectorMoving);
            _currentHp = typeEnemy.hp;
        }

        public void SetEnemyPull(EnemyPull pull)
        {
            _pull = pull;
        }

        public void GetDamage(float damage)
        {
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                KillEnemy();
            }
        }

        public void StopAttack()
        {
            _isMoving = true;
            _stateMachine.SwitchStateMoving();
        }

        public void KillEnemy()
        {
            StopAttack();
            gameObject.SetActive(false);
            var createCoin = Random.Range(0, 10) <= typeEnemy.chanceOfCoinDrop;
            if (createCoin)
            {
                var coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coin.GetComponent<Coin>().SetPrice(typeEnemy.setMoney);
            }
            _pull.MoveEnemyToPull(this.gameObject, typeEnemy);
        }

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if ((layerTower & 1 << obj.layer) == 1 << obj.layer)
            {
                StopMoving(obj.GetComponent<TowerDefaultAction>());
            }

            if ((layerBase & 1 << obj.layer) == 1 << obj.layer)
            {
                obj.GetComponent<TowerDefaultAction>().GetDamage(typeEnemy.damageForBase);
                KillEnemy();
            }
        }

        private void StopMoving(TowerDefaultAction target)
        {
            _isMoving = false;
            _stateMachine.SwitchStateAttack(target);
            Attack();
        }

        private void Attack()
        {
            if(_isMoving) return;
            _stateMachine.Update();
            StartCoroutine(RestartAttack());
        }
        private void FixedUpdate()
        {
            if(_isMoving) _stateMachine.Update();
        }

        private IEnumerator RestartAttack()
        {
            yield return new WaitForSeconds(typeEnemy.speedAttack);
            Attack();
        }
    }
}
