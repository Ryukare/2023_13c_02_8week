using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private int _currentHealth; 
    [SerializeField] private int _maxHealth;
    
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
