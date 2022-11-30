using TowerSystem.TowerActions;
using UnityEngine;

namespace _Source.Enemy.EnemyStates
{
    public class StateMoving : IStateEnemy
    {
        private Rigidbody _rb;
        private float _speedMove;
        private Vector3 _vectorMoving;

        private Vector3 _currentSpeed;

        public StateMoving(Rigidbody body, float speed, Vector3 vector)
        {
            _rb = body;
            _speedMove = speed;
            _vectorMoving = vector;
            _currentSpeed = _vectorMoving * _speedMove/100;
        }

        public void Enter(TowerDefaultAction target = null)
        {
            
        }

        public void Update()
        {
            _rb.MovePosition(_rb.position + _currentSpeed);
        }

        public void Exit()
        {
            
        }
    }
}