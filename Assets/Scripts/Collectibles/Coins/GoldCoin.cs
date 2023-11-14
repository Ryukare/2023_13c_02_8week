using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Collectible
{
    protected override void Collect()
    {
        //PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        //playerScore.IncreaseScore(10);
        //playerScore.IncreaseGoldCoinsAmount();
        GameEventSystem.IncreaseScore(10);
        GameEventSystem.IncreaseCoins();
        Destroy(gameObject);
    }
}
