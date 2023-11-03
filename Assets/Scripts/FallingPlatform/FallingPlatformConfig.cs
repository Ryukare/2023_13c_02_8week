using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/FallingPlatform Config", fileName = "FallingPlatform Config")]
public class FallingPlatformConfig : ScriptableObject
{
    public float disappearTime;
    public float cooldownTime;
}
