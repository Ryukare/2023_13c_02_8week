using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score = 0;
    private int _goldCoinCount;
    private int _goldCoinScore = 0;
    private int _diamondCount;
    private int _diamondScore = 0;

    private void Start()
    {
        _goldCoinCount = GameObject.FindGameObjectsWithTag("GoldCoin").Length;
        _diamondCount = GameObject.FindGameObjectsWithTag("Diamond").Length;
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        Debug.Log("Score: " + _score);
    }
    public void IncreaseGoldCoinsScore()
    {
        _goldCoinScore++;
        Debug.Log("Gold Coins: " + _goldCoinScore + "/" + _goldCoinCount);
    }
    public void IncreaseDiamondScore()
    {
        _diamondScore++;
        Debug.Log("Diamonds: " + _diamondScore + "/" + _diamondCount);
    }
}
