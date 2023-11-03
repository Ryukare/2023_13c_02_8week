using UnityEngine;

public class Diamond : Collectible
{
    protected override void Collect()
    {
        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        playerScore.IncreaseScore(100);
        playerScore.IncreaseDiamondsAmount();
        Destroy(gameObject);
    }
}
