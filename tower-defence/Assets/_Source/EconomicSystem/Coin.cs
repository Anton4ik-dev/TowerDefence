using System;
using System.Collections;
using EconomicSystem;
using UnityEngine;

namespace _Source.EconomicSystem
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float timeLife;
        [SerializeField] private ResourceType typeMoney;
        private int _price;

        public void AddMoney()
        {
            ResourceService.OnAddResource(_price, typeMoney);
            Destroy(this.gameObject);
        }

        public void SetPrice(int price)
        {
            _price = price;
        }

        private void Awake()
        {
            StartCoroutine(TimeLife());
        }

        private IEnumerator TimeLife()
        {
            yield return new WaitForSeconds(timeLife);
            Destroy(this.gameObject);
        }
    }
}
