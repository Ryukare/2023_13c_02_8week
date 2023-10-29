using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool isFalling = false;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float _fallRangeY = 3f;
    [SerializeField] private float _destroyDelay = 2f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _fallRangeY, LayerMask.GetMask("Player"));

            if (hit.collider != null)
            {
                isFalling = true;
                _rb.bodyType = RigidbodyType2D.Dynamic;
                Destroy(gameObject, _destroyDelay);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isFalling)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount);
        }
        else
        {
            isFalling = false;
        }
        Destroy(gameObject, _destroyDelay);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
