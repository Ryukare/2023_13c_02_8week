using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private Transform _attackPoint;

    private float _xInput;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    private bool _performJump;
    private bool _isGrounded;
    private int _jumps = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _jumps < 3)
        {
            _performJump = true;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_xInput * _playerConfig.speed, _rigidbody.velocity.y);
        _animator.SetFloat("XInputAbs", Mathf.Abs(_xInput));
        FlipX();

        _isGrounded = Physics2D
            .OverlapCircle(_groundCheck.position, _playerConfig.groundCheckRadius, _groundMask);

        if (_isGrounded)
        {
            _animator.SetBool("IsGrounded", true);
            _jumps = 0;
        }

        if (_performJump)
        {
            if(!_isGrounded )
            {
                _jumps++;
            }
            _performJump = false;
            _jumps++;
            _rigidbody.velocity = Vector2.up * _playerConfig.jumpForce;
            _animator.SetBool("IsGrounded", false);
            Debug.Log($"jumps: {_jumps}");
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        _jumps++;
        Debug.Log($"jumps: {_jumps}");
    }

    private void FlipX()
    {
        if (_xInput > 0)
        {
            _spriteRenderer.flipX = false;
            _attackPoint.position = new Vector2(transform.position.x + GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
        else if (_xInput < 0)
        {
            _spriteRenderer.flipX = true;
            _attackPoint.position = new Vector2(transform.position.x - GetComponent<CircleCollider2D>().radius,
                _attackPoint.position.y);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _playerConfig.groundCheckRadius);
    }
}
