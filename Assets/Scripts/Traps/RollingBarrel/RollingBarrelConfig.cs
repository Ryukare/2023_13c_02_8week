using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/RollingBarrel Config", fileName = "RollingBarrel Config")]
public class RollingBarrelConfig : ScriptableObject
{
    public int damage;
    public float destroyDelay;
}
