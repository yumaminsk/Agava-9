using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _changeValue = 10;
    private float _minHealth = 0;
    private float _multFactor = 15f;

    public float PlayerHealth { get; private set; }
    public float TargetHealth { get; private set; }
    public float MaxHealth { get; private set; }

    private void Awake()
    {
        MaxHealth = 100f;
        PlayerHealth = 0f;
        TargetHealth = 0f;
    }

    private void Update()
    {
        UpdateParameters();
    }

    public void TakeDamage()
    {
        if (TargetHealth > _minHealth)
        {
            TargetHealth -= _changeValue;
        }
    }

    public void Heal()
    {
        if (TargetHealth < MaxHealth)
        {
            TargetHealth += _changeValue;
        }
    }

    private void UpdateParameters()
    {
        PlayerHealth = Mathf.MoveTowards(PlayerHealth, TargetHealth, _multFactor* Time.deltaTime);
    }
}
