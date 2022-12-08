using _Source.EconomicSystem;
using TowerSystem.TowerActions;
using Random = UnityEngine.Random;
using UnityEngine;

namespace _Source.Enemy
{
    public class CrocodileAction : ABaseEnemyAction 
    {
        protected override void ChangeStartState()
        {
            StateMachine.SwitchStateMoving();
        }

        protected override void KillEnemy()
        {
            animation.PlayDead();
            IsDead = true;
            var createCoin = Random.Range(0, 10) <= typeEnemy.chanceOfCoinDrop;
            if (createCoin)
            {
                var coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coin.GetComponent<Coin>().SetPrice(typeEnemy.setMoney);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if ((layerTower & 1 << obj.layer) == 1 << obj.layer)
            {
                StopMoving(obj.GetComponent<TowerDefaultAction>());
                animation.PlayAttack();
            }

            if ((layerBase & 1 << obj.layer) == 1 << obj.layer)
            {
                obj.GetComponent<TowerDefaultAction>().GetDamage(typeEnemy.damageForBase);
                KillEnemy();
            }
        }
        protected override void Attack()
        {
            if(IsMoving) return;
            StateMachine.Update();
            StartCoroutine(RestartAttack());
        }
    }
}
