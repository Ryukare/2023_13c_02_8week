using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int damageAmount = 2;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rb.velocity = -transform.right * _speed;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) {
            Health player = other.gameObject.GetComponent<Health>();
            player.loseHP(damageAmount);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Totem")) //jesli pociski walna w cokolwiek innego
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible() //jesli pociski wylatuja poza kamere
    {
        Destroy(gameObject);
    }
}
