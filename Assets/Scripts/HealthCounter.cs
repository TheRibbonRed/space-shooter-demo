using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _healthText;
    private float _healthValue, _healthMax;

    public void SetTotalHealth(float health)
    {
        _healthValue = health;
        _healthMax = health;
    }

    public void DecreaseHealthCount(float damage)
    {
        _healthValue -= damage;
        _healthText.text = $"{_healthValue}%";
        _healthSlider.value = (((_healthValue - 0f) * (_healthSlider.maxValue - _healthSlider.minValue)) / (_healthMax - 0f)) + _healthSlider.minValue;
    }
}
