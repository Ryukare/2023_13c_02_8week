using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private Transform _attackPoint;
    private float _attackRange;
    
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private LayerMask _playerLayer;

    private float _attackCooldown;
    private int _damage;
    private float _lastAttackTime;

    void Awake()
    {
        _attackRange = _enemyConfig.attackRange;
        _damage = _enemyConfig.damage;
        _attackCooldown = _enemyConfig.attackCooldown;
    }

    void Update()
    {
        if (Time.time - _lastAttackTime >= _attackCooldown)
        {
            float distanceToPlayer = Vector2.Distance(_attackPoint.position, _playerPosition.position);

            if (distanceToPlayer <= _attackRange)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        Collider2D player = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _playerLayer);

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(_damage);

        _lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
