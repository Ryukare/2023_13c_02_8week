using UnityEngine;

public class Health : MonoBehaviour
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

    public void loseHP(int amount)
    {
        Debug.Log(gameObject.name + " lost " + amount + " HP");
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
