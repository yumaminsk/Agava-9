using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _slider.value = _player.PlayerHealth / _player.MaxHealth;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _slider.value = _player.PlayerHealth / _player.MaxHealth;
        Debug.Log(_slider.value);
    }
}
