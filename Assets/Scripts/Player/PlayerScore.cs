using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score = 0;
    private int _goldCoinCount;
    private int _goldCoinAmount = 0;
    private int _diamondCount;
    private int _diamondAmount = 0;

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
    public void IncreaseGoldCoinsAmount()
    {
        _goldCoinAmount++;
        Debug.Log("Gold Coins: " + _goldCoinAmount + "/" + _goldCoinCount);
    }
    public void IncreaseDiamondsAmount()
    {
        _diamondAmount++;
        Debug.Log("Diamonds: " + _diamondAmount + "/" + _diamondCount);
    }
}
