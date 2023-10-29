using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Transform _attackPoint;

    private float _direction;
    private float _speed;

    private bool _performJump;
    private bool _isGrounded;
    private int _jumpCount = 0;
    private float _jumpForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        _speed = _playerConfig.speed;
        _jumpForce = _playerConfig.jumpForce;
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
        _animator.SetFloat("XInputAbs", Mathf.Abs(_direction));
        FlipX();

        if (_performJump)
        {
            if (!_isGrounded)
            {
                _jumpCount++;
            }

            _performJump = false;
            _isGrounded = false;

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _animator.SetBool("IsGrounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
        _jumpCount = 0;
        _animator.SetBool("IsGrounded", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
        _animator.SetBool("IsGrounded", false);
    }

    private void FlipX()
    {
        if (_direction > 0)
        {
            _spriteRenderer.flipX = false;
            _attackPoint.position = new Vector2(transform.position.x + GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
        else if (_direction < 0)
        {
            _spriteRenderer.flipX = true;
            _attackPoint.position = new Vector2(transform.position.x - GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
    }
}
