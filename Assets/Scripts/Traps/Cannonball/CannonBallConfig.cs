using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Cannonball Config", fileName = "Cannonball Config")]
public class CannonBallConfig : ScriptableObject
{
    public int damage;
    public float fallRangeY;
    public float destroyDelay;
}
