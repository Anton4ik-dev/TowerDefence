using UnityEngine;

namespace _Source.Enemy.EnemyStates
{
    public static class CreatorEnemyState
    {
        public static StateAttack CreateStateAttack(float damage, EnemyController controller) => new StateAttack(damage, controller);
        public static StateMoving CreateStateMoving(Rigidbody body, float speed, Vector3 vector) => new StateMoving(body, speed, vector);
    }
}