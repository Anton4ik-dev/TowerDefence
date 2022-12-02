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
        private GameObject _cell;

        public void Initialize(GameObject cell)
        {
            SetMaxHP();
            _cell = cell;
        }
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
        protected void SetMaxHP()
        {
            _hp = towerSO.HP;
            sliderHP.maxValue = _hp;
            SetHP();
        }
        private void ChangeCellLayer()
        {
            _cell.layer = (int)Mathf.Log(towerSO.layerAfterTowerDestroy.value, 2);
        }
        protected virtual void DestroyTower()
        {
            gameObject.SetActive(false);
            ChangeCellLayer();
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