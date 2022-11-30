using TowerSystem.TowersSO;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem.TowerActions
{
    public class TowerDefaultAction : MonoBehaviour
    {
        [SerializeField] protected TowerDefaultSO towerSO;
        [SerializeField] private Slider sliderHP;
        private float _hp;
        public void GetDamage(float damage)
        {
            _hp -= damage;
        }
        private void SetHP()
        {
            _hp = towerSO.HP;
            sliderHP.maxValue = _hp;
            sliderHP.value = _hp;
        }
        private void Awake()
        {
            SetHP();
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