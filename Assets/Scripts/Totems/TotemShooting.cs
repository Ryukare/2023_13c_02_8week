using System;
using System.Collections;
using UnityEngine;

public class TotemShooting : MonoBehaviour
{

    [SerializeField] private TotemConfig _totemConfig;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject _projectile;

    private Transform _player;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if (_player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
        else
        {
            StartCoroutine(TotemCoroutine());
        }
    }
    private IEnumerator TotemCoroutine()
    {
        while (_player != null)
        {
            if (!_spriteRenderer.flipX)
            {
                bool playerOnLeft = _player.position.x < transform.position.x;
                if (playerOnLeft && Math.Abs(_player.position.y - transform.position.y) 
                    <= _totemConfig.shootRangeY)
                {
                    float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
                    if (distanceToPlayer <= _totemConfig.shootRangeX)
                    {
                        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y 
                            + _totemConfig.spawnOffsetY);
                        _projectile.GetComponent<SpriteRenderer>().flipX = false;
                        Instantiate(_projectile, spawnPosition, transform.rotation);
                    }
                }
            }
            else if (_spriteRenderer.flipX)
            {
                bool playerOnRight = _player.position.x > transform.position.x;
                if (playerOnRight && Math.Abs(_player.position.y - transform.position.y) 
                    <= _totemConfig.shootRangeY)
                {
                    float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
                    if (distanceToPlayer <= _totemConfig.shootRangeX)
                    {
                        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y 
                            + _totemConfig.spawnOffsetY);
                        _projectile.GetComponent<SpriteRenderer>().flipX = true;
                        Instantiate(_projectile, spawnPosition, transform.rotation);
                    }
                }
            }
            yield return new WaitForSeconds(_totemConfig.cooldown);
        }
    }
}
