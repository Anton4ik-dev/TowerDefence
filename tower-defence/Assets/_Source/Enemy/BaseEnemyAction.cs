using BattleSystem.BattleActions;
using TowerSystem.TowerActions;

namespace _Source.Enemy
{
    public interface IBaseEnemyAction
    {
        public void GetDamage(float damage, Bullet tower);
        public void StopAttack();
        public void KillEnemy(ShootingTowerAction tower);
    }
}