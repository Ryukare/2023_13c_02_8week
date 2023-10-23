using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private LayerMask _playerLayer;

    [SerializeField] private float _attackCooldown;
    [SerializeField] private int damageAmount = 2;
    private float _lastAttackTime;


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

        Health playerHealth = player.GetComponent<Health>();
        playerHealth.loseHP(damageAmount);

        _lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
