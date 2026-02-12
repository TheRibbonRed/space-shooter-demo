using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    [SerializeField] private List<PlayerBullet> _playerBullets;
    [SerializeField] private Slider _ammoSlider;
    [SerializeField] private TMP_Text _ammoText;
    [SerializeField] private UnityEvent<float> _updateAmmoEvent;
    private float _ammoMax, _ammoValue, _ammoPerBullet;

    public void SetTotalAmmo(float ammo)
    {
        _ammoMax = ammo;
        _ammoValue = ammo;
        _ammoPerBullet = _ammoValue / _playerBullets.Count;
    }

    public void SetAmmoCount(bool increase)
    {
        _ammoValue = increase ? _ammoValue + _ammoPerBullet : _ammoValue - _ammoPerBullet;
        _ammoText.text = $"{_ammoValue}%";
        _ammoSlider.value = (((_ammoValue - 0f) * (_ammoSlider.maxValue - _ammoSlider.minValue)) / (_ammoMax - 0f)) + _ammoSlider.minValue;
        _updateAmmoEvent?.Invoke(_ammoValue);
    }
}
