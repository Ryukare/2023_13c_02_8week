using UnityEngine;

public class Diamond : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        ScoreEventSystem.IncreaseScore(_config.scoreIncrease);
        ScoreEventSystem.CollectDiamond();
        Destroy(gameObject);
    }
}
