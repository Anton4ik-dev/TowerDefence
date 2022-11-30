using TowersSO;
using UnityEngine;
using UnityEngine.UI;

public class TowerDefaultAction : MonoBehaviour
{
    [SerializeField] protected TowerDefaultSO towerSO;
    [SerializeField] protected Slider sliderHP;
    protected float _hp;
    private void Awake()
    {
        SetHP();
    }
    private void SetHP()
    {
        _hp = towerSO.HP;
        sliderHP.maxValue = _hp;
    }
    private void OnMouseEnter()
    {
        sliderHP.gameObject.SetActive(true);
        sliderHP.value = _hp;
    }
    private void OnMouseExit()
    {
        sliderHP.gameObject.SetActive(false);
    }
}