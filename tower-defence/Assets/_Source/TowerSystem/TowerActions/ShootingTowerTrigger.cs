using TowerSystem.TowerActions;
using UnityEngine;

public class ShootingTowerTrigger : MonoBehaviour
{
    private ShootingTowerAction _tower;
    private LayerMask _mask;
    public void Initialize(ShootingTowerAction tower, LayerMask mask)
    {
        _tower = tower;
        _mask = mask;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((_mask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            _tower.AddEnemy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((_mask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            _tower.RemoveEnemy(other.gameObject);
    }
}
