using TowerSystem.TowerActions;

namespace _Source.Enemy.EnemyStates
{
    public interface IStateEnemy
    {
        public void Enter(TowerDefaultAction target = null);
        public void Update();
        public void Exit();
    }
}
