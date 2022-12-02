using UnityEngine;

namespace EconomicSystem
{
    public class TowerPositionChooser : MonoBehaviour
    {
        [SerializeField] private LayerMask activeLayer;
        [SerializeField] private TowerShop towerShop;
        private int _layerMask;
        private void Awake()
        {
            _layerMask = 1 << (int)Mathf.Log(activeLayer.value, 2);
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
                {
                    towerShop.BuyTower(hit.transform.gameObject);
                }
            }
        }
    }
}