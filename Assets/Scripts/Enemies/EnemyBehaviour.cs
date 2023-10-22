using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Transform _attackPoint;

    private Transform _currentDestination;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _playerPosition;

    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _chaseRange;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _currentDestination = _pointA.transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerPosition.position);

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
        if (_playerPosition.position.x > transform.position.x)
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
            Vector2.MoveTowards(transform.position, new Vector2(_playerPosition.position.x, transform.position.y),
            _chaseSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

}
