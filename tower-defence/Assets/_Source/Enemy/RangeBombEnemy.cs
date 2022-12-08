using TowerSystem.TowerActions;
using UnityEngine;

namespace _Source.Enemy
{
    public class RangeBombEnemy : MonoBehaviour
    {
        [SerializeField] private BombCrocodileAction body;
        [SerializeField] private LayerMask layerTarget;

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if ((layerTarget & 1 << obj.layer) == 1 << obj.layer)
            {
                body.AddTarget(obj.GetComponent<TowerDefaultAction>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var obj = other.gameObject;
            if ((layerTarget & 1 << obj.layer) == 1 << obj.layer)
            {
                body.RemoveTarget(obj.GetComponent<TowerDefaultAction>());
            }
        }
    }
}
