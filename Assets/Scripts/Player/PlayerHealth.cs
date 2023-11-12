using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private PlayerConfig _playerConfig;
    private int _currentHealth;

    void Awake()
    {
        PlayerEventSystem.OnPlayerHeal += Heal;
        _currentHealth = _playerConfig.MaxHealth;
    }

    public void OnDestroy()
    {
        PlayerEventSystem.OnPlayerHeal -= Heal;
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            if (_currentHealth + heal >= _playerConfig.MaxHealth)
            {
                _currentHealth = _playerConfig.MaxHealth;
                Debug.Log("Player healed " + (_playerConfig.MaxHealth - _currentHealth) + " HP");
            }
            else
            {
                _currentHealth += heal;
                Debug.Log("Player healed " + heal + " HP");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }
        _currentHealth -= damage;
        
        Debug.Log("Player took " + damage + " damage");
        if (_currentHealth <= 0)
        {
            //Animacja œmierci
            Destroy(gameObject);
        }
        //else
        //Animacja hita
    }
}
