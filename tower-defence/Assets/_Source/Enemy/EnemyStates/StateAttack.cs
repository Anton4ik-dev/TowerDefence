
using TowerSystem.TowerActions;

namespace _Source.Enemy.EnemyStates
{
    public class StateAttack : IStateEnemy
    {
        private TowerDefaultAction _target;
        private float _damage;

        public StateAttack(float damage)
        {
            _damage = damage;
        }

        public void Enter(TowerDefaultAction target)
        {
            _target = target;
        }

        public void Update()
        {
            if(_target != null)_target.GetDamage(_damage);
        }

        public void Exit()
        {
            
        }
    }
}