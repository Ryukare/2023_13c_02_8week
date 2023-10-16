using System.Collections;
using UnityEngine;

public class Totem : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _spawnOffsetY = -0.45f;
    [SerializeField] private float _shootRangeX = 5.0f;
    [SerializeField] private float _shootRangeY = 0.5f;

    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
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
        while (true)
        {
            float playerXPosition = player.position.x;
            float playerYPosition = player.position.y;
            float totemXPosition = transform.position.x;
            bool playerOnLeft = playerXPosition < totemXPosition;

            if (playerOnLeft && Mathf.Abs(playerYPosition - transform.position.y) <= _shootRangeY)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.position);
                if (distanceToPlayer <= _shootRangeX)
                {
                    Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + _spawnOffsetY);
                    Instantiate(_projectilePrefab, spawnPosition, transform.rotation);
                }
            }
            yield return new WaitForSeconds(_cooldown);
        }
    }
}
