using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private PlayerConfig _playerConfig;

    private int _currentHealthValue;
    private int _currentHealth
    {
        get => _currentHealthValue;
        set
        {
            _currentHealthValue = value;
            PlayerHealthEventSystem.UpdatePlayerHealth(value);
        }
    }

    private void Awake()
    {
        PlayerHealthEventSystem.OnPlayerHeal += Heal;
        PlayerHealthEventSystem.OnPlayerHit += TakeDamage;
    }

    private void Start()
    {
        _currentHealth = _playerConfig.MaxHealth;
    }

    public void OnDestroy()
    {
        PlayerHealthEventSystem.OnPlayerHeal -= Heal;
        PlayerHealthEventSystem.OnPlayerHit -= TakeDamage;
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            if (_currentHealth + heal >= _playerConfig.MaxHealth)
            {
                _currentHealth = _playerConfig.MaxHealth;
            }
            else
            {
                _currentHealth += heal;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                //Animacja œmierci
                Destroy(gameObject);
            }
            //else
            //Animacja hita
        }
    }
}
