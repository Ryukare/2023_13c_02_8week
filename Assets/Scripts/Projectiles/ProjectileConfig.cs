using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Projectile Config", fileName = "Projectile Config")]
public class ProjectileConfig : ScriptableObject
{
    public int speed;
    public int damage;
}
