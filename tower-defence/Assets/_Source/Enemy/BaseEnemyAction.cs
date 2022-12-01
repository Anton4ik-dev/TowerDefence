namespace _Source.Enemy
{
    public interface IBaseEnemyAction
    {
        public void GetDamage(float damage);
        public void StopAttack();
        public void KillEnemy();
    }
}