using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Transform _attackPoint;

    private Transform _currentDestination;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    private Transform _player;

    private float _patrolSpeed;
    private float _chaseSpeed;
    private float _chaseRange;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _patrolSpeed = _enemyConfig.patrolSpeed;
        _chaseRange = _enemyConfig.chaseRange;
        _chaseSpeed = _enemyConfig.chaseSpeed;
    }

    void Start()
    {
        _currentDestination = _pointA.transform;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer <= _chaseRange)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }
    private void Patrol()
    {
        if (_currentDestination == _pointA)
        {
            _spriteRenderer.flipX = false;
            _attackPoint.position = new Vector2(transform.position.x - GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
        else
        {
            _spriteRenderer.flipX = true;
            _attackPoint.position = new Vector2(transform.position.x + GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentDestination.position,
        _patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _currentDestination.position) <= 0.2f)
        {
            if (_currentDestination == _pointA)
            {
                _currentDestination = _pointB;
            }
            else
            {
                _currentDestination = _pointA;
            }
        }
    }
    private void Chase()
    {
        if (_player.position.x > transform.position.x)
        {
            _spriteRenderer.flipX = true;
            _attackPoint.position = new Vector2(transform.position.x + GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
        else
        {
            _spriteRenderer.flipX = false; _attackPoint.position = new Vector2(transform.position.x - GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
        transform.position =
            Vector2.MoveTowards(transform.position, new Vector2(_player.position.x, transform.position.y),
            _chaseSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

}
