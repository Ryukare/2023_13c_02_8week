using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : Collectible
{

    [SerializeField] private PotionConfig _healPotionConfig;
    protected override void Collect()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.Heal(_healPotionConfig.potionStrength);
        Destroy(gameObject);
    }
}
