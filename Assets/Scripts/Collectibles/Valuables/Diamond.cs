using UnityEngine;

public class Diamond : Collectible
{
    [SerializeField] private ValuableConfig _config;
    protected override void Collect()
    {
        PlayerEventSystem.CollectValuable(_config.valuableName, _config.scoreIncrease);
        Destroy(gameObject);
    }
}
