using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBarrelBehaviour : MonoBehaviour
{
    [SerializeField] private RollingBarrelConfig _barrelConfig;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void StartRoll(Vector2 direction, float rollSpeed)
    {
        rb.velocity = direction * rollSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(_barrelConfig.damage);
                Destroy(gameObject);
            }
        }
        Destroy(gameObject, _barrelConfig.destroyDelay);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
