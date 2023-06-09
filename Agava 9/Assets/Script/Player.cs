using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _changeValue = 10;
    private float _minHealth = 0;

    public float PlayerHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public event Action<float> HealthChanged;

    private void Awake()
    {
        MaxHealth = 100f;
        PlayerHealth = 0f;
    }

    public void TakeDamage()
    {
        if (PlayerHealth > _minHealth)
        {
            PlayerHealth -= _changeValue;
            HealthChanged?.Invoke(PlayerHealth);
        }
    }

    public void Heal()
    {
        if (PlayerHealth < MaxHealth)
        {
            PlayerHealth += _changeValue;
            HealthChanged?.Invoke(PlayerHealth);
        }
    }
}
