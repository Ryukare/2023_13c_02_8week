using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    private Animator _animator;
    private int _currentHealth;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _enemyConfig.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _animator.SetTrigger("Death");
                Destroy(gameObject);
            }
            else
            {
                _animator.SetTrigger("GetHit");
            }
        }
        
    }
}

