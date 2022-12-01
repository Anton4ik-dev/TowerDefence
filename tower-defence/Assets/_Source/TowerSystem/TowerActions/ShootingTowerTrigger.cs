using TowerSystem.TowerActions;
using UnityEngine;

public class ShootingTowerTrigger : MonoBehaviour
{
    [SerializeField] private ShootingTowerAction tower;
    [SerializeField] private LayerMask mask;
    private void OnTriggerEnter(Collider other)
    {
        if ((mask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            tower.AddEnemy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((mask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            tower.RemoveEnemy(other.gameObject);
    }
}
