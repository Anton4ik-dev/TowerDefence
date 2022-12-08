using System;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private ABaseEnemyAction main;
        private int _idAttack;
        private int _idDead;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _idAttack = Animator.StringToHash("isAttack");
            _idDead = Animator.StringToHash("DeadTrigger");
        }

        public void PlayAttack()
        {
            _animator.SetBool(_idAttack, true);
        }

        public void PlayIdle()
        {
            _animator.SetBool(_idAttack, false);
        }

        public void DeadEnemy()
        {
            main.DeadEnemy();
        }
        public void PlayDead()
        {
            _animator.SetTrigger(_idDead);
        }
    }
}
