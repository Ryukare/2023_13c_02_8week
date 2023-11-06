using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool isFalling = false;
    [SerializeField] private CannonBallConfig _cannonBallConfig;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _cannonBallConfig.fallRangeY, LayerMask.GetMask("Player"));

            if (hit.collider != null)
            {
                isFalling = true;
                _rb.bodyType = RigidbodyType2D.Dynamic;
                Destroy(gameObject, _cannonBallConfig.destroyDelay);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isFalling)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(_cannonBallConfig.damage);
        }
        else
        {
            isFalling = false;
        }
        Destroy(gameObject, _cannonBallConfig.destroyDelay);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
