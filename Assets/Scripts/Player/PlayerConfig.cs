using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Config", fileName = "Player config")]
public class PlayerConfig : ScriptableObject
{
    public int MaxHealth;
    public int damage;
    public float speed;
    public float jumpForce;
    public float attackRange;
}
