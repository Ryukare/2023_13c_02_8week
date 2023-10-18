using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject _pointA;
    [SerializeField] private GameObject _pointB;

    private bool _chasing;

    private Transform _currentDestination;
    private Transform _playerPosition;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _currentDestination = _pointA.transform;
        _playerPosition = GameObject.FindWithTag("Player").transform;
        _chasing = false;
    }

    void Update()
    {
        if (!_chasing)
        {
            if (_currentDestination == _pointA.transform)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, _currentDestination.position,
            _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _currentDestination.position) < 0.2f)
            {
                if (_currentDestination == _pointA.transform)
                {
                    _currentDestination = _pointB.transform;
                }
                else
                {
                    _currentDestination = _pointA.transform;
                }
            }
        }
        else
        {
            if(_playerPosition.position.x > transform.position.x)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
            transform.position = 
                Vector2.MoveTowards(transform.position, new Vector2(_playerPosition.position.x, transform.position.y), 
                _speed * 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _chasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _chasing = false;
        }
    }
}
