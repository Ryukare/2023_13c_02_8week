using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    [SerializeField] private ProjectileConfig _config;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rigidbody.velocity = _direction * _config.speed;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) {
            PlayerEventSystem.HitPlayer(_config.damage);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Totem")) //jesli pociski walna w cokolwiek innego
        {
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    private void OnBecameInvisible() //jesli pociski wylatuja poza kamere
    {
        Destroy(gameObject);
    }
}
