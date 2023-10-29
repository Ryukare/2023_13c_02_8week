using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Config", fileName = "Enemy config")]
public class EnemyConfig : ScriptableObject
{
    public int MaxHealth;
    public int damage;
    public float attackRange;
    public int attackCooldown;
    public float patrolSpeed;
    public float chaseRange;
    public float chaseSpeed;
}
