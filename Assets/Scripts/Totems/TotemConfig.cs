using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Totem Config", fileName = "Totem Config")]
public class TotemConfig : ScriptableObject
{
    public float shootRangeX;
    public float shootRangeY;
    public float spawnOffsetY;
    public int cooldown;
}
