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
        [SerializeField] protected EnemyAnimationController animation;
        
        public TypeEnemySo GetTypeEnemy => typeEnemy;
        protected EnemyStateMachine StateMachine;
        protected bool IsMoving = true;
        protected bool IsDead;
        private float _currentHp;
        private EnemyPull _pull;
        
        private void Awake()
        {
            StateMachine = new EnemyStateMachine(GetComponent<Rigidbody>(), typeEnemy, vectorMoving);
            ResetHp();
            ChangeStartState();
        }

        protected virtual void ChangeStartState()
        {
            
        }

        public void DeadEnemy()
        {
            this.gameObject.SetActive(false);
            IsDead = false;
            StopAttack();
            ResetHp();
            _pull.MoveEnemyToPull(this.gameObject, typeEnemy);
        }
        protected void ResetHp()
        {
            _currentHp = typeEnemy.hp;
        }
        public void SetEnemyPull(EnemyPull pull)
        {
            _pull = pull;
        }

        public void GetDamage(float damage)
        {
            if(IsDead) return;
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                KillEnemy();
            }
        }
        public void StopAttack()
        {
            animation.PlayIdle();
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
            if(IsMoving & IsDead == false) StateMachine.Update();
        }
    }
}