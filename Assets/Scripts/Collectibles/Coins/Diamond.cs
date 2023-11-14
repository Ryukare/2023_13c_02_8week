using UnityEngine;

public class Diamond : Collectible
{
    protected override void Collect()
    {
        //PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        //playerScore.IncreaseScore(100);
        //playerScore.IncreaseDiamondsAmount();
        GameEventSystem.IncreaseScore(100);
        GameEventSystem.IncreaseDiamonds();
        Destroy(gameObject);
    }
}
