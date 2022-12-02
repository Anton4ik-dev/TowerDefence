using _Source.EconomicSystem;
using UnityEngine;

namespace _Source.Enemy
{
    public class CollectorCoin : MonoBehaviour
    {
        [SerializeField] private LayerMask layerCoin;
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerCoin))
                {
                    Debug.Log("coin");
                    hit.collider.GetComponent<Coin>().AddMoney();
                }
            }
        }
    }
}
