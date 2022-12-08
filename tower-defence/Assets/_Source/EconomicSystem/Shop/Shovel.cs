using TowerSystem.TowerActions;
using UnityEngine;

namespace EconomicSystem
{
    public class Shovel : MonoBehaviour
    {
        [SerializeField] private LayerMask towerLayer;
        [SerializeField] private TowerShop towerShop;
        private int _towerLayerMask;
        private void Awake()
        {
            _towerLayerMask = 1 << (int)Mathf.Log(towerLayer.value, 2);
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _towerLayerMask))
                {
                    TowerDefaultAction towerAction = hit.transform.gameObject.GetComponent<TowerDefaultAction>();
                    towerAction.DestroyTower();
                    ResourceService.OnAddResource?.Invoke(towerAction.towerSO.Cost, towerAction.towerSO.ResourceForBuy);
                }
                towerShop.DisableShovel();
            }
        }
    }
}