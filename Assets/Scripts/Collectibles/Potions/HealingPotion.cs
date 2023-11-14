using UnityEngine;

public class HealingPotion : Collectible
{

    [SerializeField] private PotionConfig _healPotionConfig;
    protected override void Collect()
    {
        PlayerEventSystem.HealPlayer(_healPotionConfig.potionStrength);
        Destroy(gameObject);
    }
}
