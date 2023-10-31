using UnityEngine;

public class GoldCoin : Collectible
{
    protected override void Collect()
    {
        Destroy(gameObject);
    }
}
