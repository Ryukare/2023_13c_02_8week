using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private Transform _attackPoint;
    private float _attackRange;
    private int _damage;

    void Awake()
    {
        _attackRange = _playerConfig.attackRange;
        _damage = _playerConfig.damage;
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
        //Animacja ataku

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.loseHP(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
