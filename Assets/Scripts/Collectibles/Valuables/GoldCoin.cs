using UnityEngine;

public class GoldCoin : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        PlayerEventSystem.IncreaseScore(_config.scoreIncrease);
        PlayerEventSystem.CollectGoldCoin();
        Destroy(gameObject);
    }
}
