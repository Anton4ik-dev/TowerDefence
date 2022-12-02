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
            SetHP();
            if (_hp <= 0)
                DestroyTower();
        }
        private void SetHP()
        {
            sliderHP.value = _hp;
        }
        private void SetMaxHP()
        {
            _hp = towerSO.HP;
            sliderHP.maxValue = _hp;
            SetHP();
        }
        protected virtual void DestroyTower()
        {
            gameObject.SetActive(false);
        }
        private void Awake()
        {
            SetMaxHP();
        }
        protected virtual void OnMouseEnter()
        {
            sliderHP.gameObject.SetActive(true);
            SetHP();
        }
        protected virtual void OnMouseExit()
        {
            sliderHP.gameObject.SetActive(false);
        }
    }
}