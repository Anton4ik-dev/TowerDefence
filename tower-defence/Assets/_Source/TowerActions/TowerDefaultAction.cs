using TowersSO;
using UnityEngine;
using UnityEngine.UI;

namespace TowerActions
{
    public class TowerDefaultAction : MonoBehaviour
    {
        [SerializeField] protected TowerDefaultSO towerSO;
        [SerializeField] private Slider sliderHP;
        private float _hp;
        private void Awake()
        {
            SetHP();
        }
        private void SetHP()
        {
            _hp = towerSO.HP;
            sliderHP.maxValue = _hp;
            sliderHP.value = _hp;
        }

        public void SetDamage(float damage)
        {
            
        }
        protected virtual void OnMouseEnter()
        {
            sliderHP.gameObject.SetActive(true);
            sliderHP.value = _hp;
        }
        protected virtual void OnMouseExit()
        {
            sliderHP.gameObject.SetActive(false);
        }
    }
}