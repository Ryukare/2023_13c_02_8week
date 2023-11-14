using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private Transform _attackPoint;
    
    [SerializeField] private LayerMask _playerLayer;
    private Transform _player;

    private float _lastAttackTime;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time - _lastAttackTime >= _config.attackCooldown)
        {
            float distanceToPlayer = Vector2.Distance(_attackPoint.position, _player.position);

            if (distanceToPlayer <= _config.attackRange)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        Collider2D player = Physics2D.OverlapCircle(_attackPoint.position, _config.attackRange, _playerLayer);

        if (player != null)
        {
            PlayerEventSystem.HitPlayer(_config.damage);
        }

        _lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _config.attackRange);
    }
}
