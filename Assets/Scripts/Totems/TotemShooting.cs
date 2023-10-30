using System;
using System.Collections;
using Unity.VisualScripting;
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
        while (true && _player != null)
        {
            float playerPositionX = _player.position.x;
            float playerPositionY = _player.position.y;
            float totemXPosition = transform.position.x;
            bool playerOnLeft = playerPositionX < totemXPosition;

            if (playerOnLeft && Math.Abs(playerPositionY - transform.position.y) <= _totemConfig.shootRangeY && !_spriteRenderer.flipX)
            {
                Shoot(Vector2.left);
            }
            else if (!playerOnLeft && Math.Abs(playerPositionY - transform.position.y) <= _totemConfig.shootRangeY && _spriteRenderer.flipX)
            {
                Shoot(Vector2.right);
            }
            yield return new WaitForSeconds(_totemConfig.cooldown);
        }
    }
    private void Shoot(Vector2 direction)
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        if (distanceToPlayer <= _totemConfig.shootRangeX)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + _totemConfig.spawnOffsetY);
            GameObject projectile = Instantiate(_projectile, spawnPosition, transform.rotation);

            // dostep do skryptu z projectile
            ProjectileBehaviour projectileScript = projectile.GetComponent<ProjectileBehaviour>();
            if (projectileScript != null)
            {
                projectileScript.SetDirection(direction);
            }
        }
    }
}
