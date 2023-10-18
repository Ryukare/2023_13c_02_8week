using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private float _direction;
    [SerializeField] private float _speed;

    private bool _performJump;
    private bool _isGrounded;
    private int _jumpCount = 0;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _direction = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _performJump = true;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction * _speed, _rigidbody.velocity.y);

        if (_performJump)
        {
            if (!_isGrounded)
            {
                _jumpCount++;
            }

            _performJump = false;
            _isGrounded = false;

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

        FlipX();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
        _jumpCount = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
        _jumpCount++;
    }

    private void FlipX()
    {
        if (_direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
