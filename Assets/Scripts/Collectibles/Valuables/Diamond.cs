using UnityEngine;

public class Diamond : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        PlayerEventSystem.IncreaseScore(_config.scoreIncrease);
        PlayerEventSystem.CollectDiamond();
        Destroy(gameObject);
    }
}
