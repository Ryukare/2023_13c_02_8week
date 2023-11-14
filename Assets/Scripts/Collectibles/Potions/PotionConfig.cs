using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Potion Config", fileName = "Potion Config")]
public class PotionConfig : ScriptableObject
{
    public string Name;
    public int healAmount;
}
