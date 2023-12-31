using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyConfig _config;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] private Transform _attackPoint;
    private float _lastAttackTime;

    private Transform _currentDestination;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    [SerializeField] private LayerMask _playerLayer;
    private Transform _player;
    private bool _isPlayerAlive;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        PlayerHealthEventSystem.OnPlayerDeath += DisableEnemy;
    }
    private void Start()
    {
        _currentDestination = _pointA.transform;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _isPlayerAlive = true;
    }

    private void OnDestroy()
    {
        PlayerHealthEventSystem.OnPlayerDeath -= DisableEnemy;
    }

    private void Update()
    {
        if (_isPlayerAlive)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer <= _config.chaseRange)
            {
                _animator.SetBool("PlayerSpotted", true);
                distanceToPlayer = Vector2.Distance(_attackPoint.position, _player.position);
                if (distanceToPlayer <= _config.attackRange)
                {
                    if (Time.time - _lastAttackTime >= _config.attackCooldown)
                    {
                        _animator.SetTrigger("Attack");
                        Attack();
                    }
                }
                else
                {
                    Chase();
                }
            }
            else
            {
                _animator.SetBool("PlayerSpotted", false);
                Patrol();
            }
        }
    }

    private void Patrol()
    {
        if (_currentDestination == _pointA)
        {
            _spriteRenderer.flipX = false;
            _attackPoint.position = new Vector2(transform.position.x - GetComponent<CapsuleCollider2D>().size.x,
                _attackPoint.position.y);
        }
        else
        {
            _spriteRenderer.flipX = true;
            _attackPoint.position = new Vector2(transform.position.x + GetComponent<CapsuleCollider2D>().size.x,
                _attackPoint.position.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentDestination.position,
        _config.patrolSpeed * Time.deltaTime);

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
            _attackPoint.position = new Vector2(transform.position.x + GetComponent<CapsuleCollider2D>().size.x,
                _attackPoint.position.y);
        }
        else
        {
            _spriteRenderer.flipX = false; 
            _attackPoint.position = new Vector2(transform.position.x - GetComponent<CapsuleCollider2D>().size.x,
                _attackPoint.position.y);
        }
        transform.position =
            Vector2.MoveTowards(transform.position, new Vector2(_player.position.x, transform.position.y),
            _config.chaseSpeed * Time.deltaTime);
    }
    private void Attack()
    {
        Collider2D player = Physics2D.OverlapCircle(_attackPoint.position, _config.attackRange, _playerLayer);

        if (player != null)
        {
            PlayerHealthEventSystem.HitPlayer(_config.damage);
        }

        _lastAttackTime = Time.time;
    }

    private void DisableEnemy()
    {
        _isPlayerAlive = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _config.chaseRange);
        Gizmos.DrawWireSphere(_attackPoint.position, _config.attackRange);
    }

}
