
using TowerSystem.TowerActions;

namespace _Source.Enemy.EnemyStates
{
    public class StateAttack : IStateEnemy
    {
        private TowerDefaultAction _target;
        private EnemyController _controller;
        private float _damage;

        public StateAttack(float damage, EnemyController body)
        {
            _damage = damage;
            _controller = body;
        }

        public void Enter(TowerDefaultAction target)
        {
            _target = target;
        }

        public void Update()
        {
            if (_target != null)
            {
                if(_target.GetDamage(_damage))
                    _controller.StopAttack();
            }
        }

        public void Exit()
        {
            
        }
    }
}