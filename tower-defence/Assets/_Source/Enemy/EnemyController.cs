using System;
using System.Collections;
using _Source.Enemy.EnemySO;
using TowerSystem.TowerActions;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private TypeEnemySo typeEnemy;
        [SerializeField] private Vector3 vectorMoving;
        [SerializeField] private LayerMask layerTower;
        private EnemyStateMachine _stateMachine;
        private bool _isMoving = true;

        private void Awake()
        {
            _stateMachine = new EnemyStateMachine(GetComponent<Rigidbody>(), typeEnemy, vectorMoving);
        }

        public void StopAttack()
        {
            _isMoving = true;
            _stateMachine.SwitchStateMoving();
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
