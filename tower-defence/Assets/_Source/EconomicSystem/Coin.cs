using System;
using System.Collections;
using EconomicSystem;
using UnityEngine;

namespace _Source.EconomicSystem
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float timeLife;
        [SerializeField] private int count;
        
        public void AddMoney()
        {
            ResourceService.OnAddResource(count, ResourceType.Gold);
            Destroy(this.gameObject);
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
