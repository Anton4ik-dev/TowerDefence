using System.Collections;
using _Source.Enemy.EnemySO;
using _Source.Enemy.EnemyStates;
using TowerSystem.TowerActions;
using UnityEngine;

namespace _Source.Enemy
{
    public abstract class ABaseEnemyAction : MonoBehaviour
    {
        [SerializeField] protected GameObject coinPrefab;
        [SerializeField] protected TypeEnemySo typeEnemy;
        [SerializeField] protected Vector3 vectorMoving;
        [SerializeField] protected LayerMask layerTower;
        [SerializeField] protected LayerMask layerBase;
        
        public TypeEnemySo GetTypeEnemy => typeEnemy;
        protected EnemyStateMachine StateMachine;
        protected bool IsMoving = true;
        protected float CurrentHp;
        protected EnemyPull Pull;
        
        private void Awake()
        {
            StateMachine = new EnemyStateMachine(GetComponent<Rigidbody>(), typeEnemy, vectorMoving);
            ResetHp();
            ChangeStartState();
        }

        protected virtual void ChangeStartState()
        {
            
        }
        protected void ResetHp()
        {
            CurrentHp = typeEnemy.hp;
        }
        public void SetEnemyPull(EnemyPull pull)
        {
            Pull = pull;
        }

        public void GetDamage(float damage)
        {
            CurrentHp -= damage;
            if (CurrentHp <= 0)
            {
                KillEnemy();
            }
        }
        public void StopAttack()
        {
            IsMoving = true;
            StateMachine.SwitchStateMoving();
        }
        protected void StopMoving(TowerDefaultAction target)
        {
            IsMoving = false;
            StateMachine.SwitchStateAttack(target);
            Attack();
        }

        protected virtual void Attack()
        {
            
        }

        protected virtual void KillEnemy()
        {
            
        }
        protected IEnumerator RestartAttack()
        {
            yield return new WaitForSeconds(typeEnemy.speedAttack);
            Attack();
        }
        private void FixedUpdate()
        {
            if(IsMoving) StateMachine.Update();
        }
    }
}