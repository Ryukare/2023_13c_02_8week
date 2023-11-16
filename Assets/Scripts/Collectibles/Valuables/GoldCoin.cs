using UnityEngine;

public class GoldCoin : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        ScoreEventSystem.IncreaseScore(_config.scoreIncrease);
        ScoreEventSystem.CollectGoldCoin();
        Destroy(gameObject);
    }
}
