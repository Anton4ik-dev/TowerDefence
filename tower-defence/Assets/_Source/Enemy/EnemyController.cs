using System;
using System.Collections;
using _Source.Enemy.EnemySO;
using _Source.Enemy.EnemyStates;
using BattleSystem.BattleActions;
using TowerSystem.TowerActions;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemyController : MonoBehaviour, IBaseEnemyAction
    {
        [SerializeField] private TypeEnemySo typeEnemy;
        [SerializeField] private Vector3 vectorMoving;
        [SerializeField] private LayerMask layerTower;
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
            _pull.MoveEnemyToPull(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if ((layerTower & 1 << obj.layer) == 1 << obj.layer)
            {
                StopMoving(obj.GetComponent<TowerDefaultAction>());
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
