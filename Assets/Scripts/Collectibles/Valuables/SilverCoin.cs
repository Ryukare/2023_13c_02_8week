using UnityEngine;

public class SilverCoin : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        PlayerEventSystem.IncreaseScore(_config.scoreIncrease);
        PlayerEventSystem.CollectSilverCoin();
        Destroy(gameObject);
    }
}
