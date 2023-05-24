using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _sliderValue = 1;
    private float _playerHealth = 0;
    private float _currentHealth = 0;
    private float _changeValue = 10;
    private float _minHealth = 0;
    private float _maxHealth = 100;
    private float _multFactor = 15f;

    private void Awake()
    {
        _slider.value = _currentHealth;
        _slider.value = _playerHealth;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void TakeDamage()
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth -= _changeValue;
        }
    }

    public void Heal()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _changeValue;
        }
    }

    private void UpdateHealthBar()
    {
        _playerHealth = Mathf.MoveTowards(_playerHealth, _currentHealth, _multFactor * Time.deltaTime);
        _sliderValue = _playerHealth / _maxHealth;
        _slider.value = _sliderValue;
    }
}
