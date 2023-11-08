using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Config", fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public int MaxHealth;
    public int damage;
    public float speed;
    public float jumpForce;
    public float attackRange;
    public float groundCheckRadius;
}
