using System;
using System.Collections.Generic;
using _Source.Enemy.EnemySO;
using _Source.Enemy.EnemyStates;
using TMPro;
using TowerSystem.TowerActions;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemyStateMachine
    {
        private Dictionary<Type, IStateEnemy> _states;
        private IStateEnemy _currentState;

        public EnemyStateMachine(Rigidbody body, TypeEnemySo parameters, Vector3 vectorMoving)
        {
            var stateAttack = CreatorEnemyState.CreateStateAttack(parameters.damage, body.GetComponent<ABaseEnemyAction>());
            var stateMoving = CreatorEnemyState.CreateStateMoving(body, parameters.speedMove, vectorMoving);
            _states = new Dictionary<Type, IStateEnemy>();
            _states.Add(typeof(StateAttack), stateAttack);
            _states.Add(typeof(StateMoving), stateMoving);
        }

        public void SwitchStateAttack(TowerDefaultAction target)
        {
            if(_currentState != null)_currentState.Exit();
            _currentState = _states[typeof(StateAttack)];
            _currentState.Enter(target);
        }

        public void SwitchStateMoving()
        {
            if(_currentState != null)_currentState.Exit();
            _currentState = _states[typeof(StateMoving)];
            _currentState.Enter();
        }

        public void Update()
        {
            if(_currentState != null)_currentState.Update();
        }
    }
}