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

    public void loseHP()
    {
        Debug.Log(gameObject.name + " lost hp");
        _currentHealth--;
    }
}
