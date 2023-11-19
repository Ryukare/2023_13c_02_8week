using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    private Animator _animator;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private Transform _attackPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, 
            _playerConfig.attackRange, _enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(_playerConfig.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _playerConfig.attackRange);
    }
}
