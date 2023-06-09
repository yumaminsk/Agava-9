using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class Menu : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Player _player;
    private float _playerHealth = 0;
    private float _targetHealth = 0;
    private float _multFactor = 15f;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _player.HealthChanged += ChangeTarget;
    }

    private void ChangeTarget(float playerHealth)
    {
        _targetHealth = playerHealth;

        StopCoroutine(UpdateSlider());
        StartCoroutine(UpdateSlider());
    }

    IEnumerator UpdateSlider()
    {
        while(_playerHealth != _targetHealth)
        {
            _playerHealth = Mathf.MoveTowards(_playerHealth, _targetHealth, _multFactor * Time.deltaTime);
            _slider.value = _playerHealth / _player.MaxHealth;

            yield return new WaitForEndOfFrame();
        }
    }
}
