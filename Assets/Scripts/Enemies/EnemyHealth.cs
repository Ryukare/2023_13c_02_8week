using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    private int _currentHealth;

    void Awake()
    {
        _currentHealth = _enemyConfig.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }
        _currentHealth -= damage;
        //Animacja hita
        Debug.Log(gameObject.name + " took " + damage + " damage");

        if (_currentHealth <= 0)
        {
            //Animacja œmierci
            Destroy(gameObject);
        }
    }
}

