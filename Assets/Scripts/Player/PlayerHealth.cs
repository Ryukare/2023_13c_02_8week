using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private PlayerConfig _playerConfig;
    private int _currentHealthValue;

    private int CurrentHealth
    {
        get => _currentHealthValue; set
        {
            _currentHealthValue = value;
            GameEventSystem.UpdatePlayerHealth(value);
        }
    }

    void Awake()
    {
        CurrentHealth = _playerConfig.MaxHealth;
    }

    private void Start()
    {
        GameEventSystem.onPlayerHeal += Heal;
    }
    private void OnDestroy()
    {
        GameEventSystem.onPlayerHeal -= Heal;
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            if (CurrentHealth + heal >= _playerConfig.MaxHealth)
            {
                CurrentHealth = _playerConfig.MaxHealth;
                Debug.Log("Player healed " + (_playerConfig.MaxHealth - CurrentHealth) + " HP");
            }
            else
            {
                CurrentHealth += heal;
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
        CurrentHealth -= damage;
        //Animacja hita
        Debug.Log("Player took " + damage + " damage");

        if (CurrentHealth <= 0)
        {
            //Animacja œmierci
            Destroy(gameObject);
        }
    }
}
