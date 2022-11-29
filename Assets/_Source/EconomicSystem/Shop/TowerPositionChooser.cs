using UnityEngine;

namespace EconomicSystem
{
    public class TowerPositionChooser : MonoBehaviour
    {
        [SerializeField] private LayerMask activeLayer;
        [SerializeField] private TowerShop towerShop;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if ((activeLayer & 1 << hit.transform.gameObject.layer) == 1 << hit.transform.gameObject.layer)
                        towerShop.BuyTower(hit.transform.gameObject);
                }
            }
        }
    }
}