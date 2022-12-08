using System;
using System.Collections.Generic;
using _Source.EconomicSystem;
using TowerSystem.TowerActions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Enemy
{
    public class BombCrocodileAction : ABaseEnemyAction
    {
        private List<TowerDefaultAction> _towersInRange;
        protected override void ChangeStartState()
        {
            StateMachine.SwitchStateMoving();
            _towersInRange = new List<TowerDefaultAction>();
        }

        public void AddTarget(TowerDefaultAction target)
        {
            _towersInRange.Add(target);
        }

        public void RemoveTarget(TowerDefaultAction target)
        {
            _towersInRange.Remove(target);
        }

        protected override void KillEnemy()
        {
            IsDead = true;
            animation.PlayDead();
            foreach (var target in _towersInRange)
            {
                target.GetDamage(typeEnemy.damage);
            }
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
            if ((layerBase & 1 << obj.layer) == 1 << obj.layer || (layerTower & 1 << obj.layer) == 1 << obj.layer)
            {
                KillEnemy();
            }
        }
    }
}
