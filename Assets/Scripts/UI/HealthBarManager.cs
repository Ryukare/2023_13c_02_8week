using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerConfig _config;

    private void Awake()
    {
        PlayerHealthEventSystem.OnPlayerHealthUpdate += UpdatePlayerHealth;
    }

    private void Start()
    {
        _healthSlider.maxValue = _config.MaxHealth;
        _healthSlider.value = _config.MaxHealth;
    }

    private void OnDestroy()
    {
        PlayerHealthEventSystem.OnPlayerHealthUpdate -= UpdatePlayerHealth;
    }

    private void UpdatePlayerHealth(int currentHealth)
    {
        _healthSlider.value = currentHealth;
    }

}
