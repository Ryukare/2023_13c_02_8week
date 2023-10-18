using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void loseHP()
    {
        _currentHealth--;
    }
}
