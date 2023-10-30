using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    [SerializeField] private ProjectileConfig _projectileConfig;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if(_spriteRenderer.flipX)
        {
            _rigidbody.velocity = transform.right * _projectileConfig.speed;
        }
        else if (!_spriteRenderer.flipX)
        {
            _rigidbody.velocity = -transform.right * _projectileConfig.speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            player.TakeDamage(_projectileConfig.damage);
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
