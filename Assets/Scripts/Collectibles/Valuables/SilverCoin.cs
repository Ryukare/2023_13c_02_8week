using UnityEngine;

public class SilverCoin : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        ScoreEventSystem.IncreaseScore(_config.scoreIncrease);
        ScoreEventSystem.CollectSilverCoin();
        Destroy(gameObject);
    }
}
