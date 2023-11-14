using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score;
    private int _goldCoinCount;
    private int _goldCoinAmount;
    private int _diamondCount;
    private int _diamondAmount;

    private int CurrentScore
    {
        get => _score; set
        {
            _score = value;
            GameEventSystem.UpdateScore(value);
        }
    }
    private int CurrentCoinsAmount
    {
        get => _goldCoinAmount; set
        {
            _goldCoinAmount = value;
            GameEventSystem.UpdateCoins(value);
        }
    }
    private int CurrentDiamondsAmount
    {
        get => _diamondAmount; set
        {
            _diamondAmount = value;
            GameEventSystem.UpdateDiamonds(value);
        }
    }

    private void Awake()
    {
        CurrentScore = 0;
        CurrentCoinsAmount = 0;
        CurrentDiamondsAmount = 0;
        //do wykorzystania pozniej rozbudowa HUD'a ile przedmiotow jest ogolem na mapie
        _goldCoinCount = GameObject.FindGameObjectsWithTag("GoldCoin").Length;
        _diamondCount = GameObject.FindGameObjectsWithTag("Diamond").Length;
    }
    private void Start()
    {
        GameEventSystem.onIncreaseScore += IncreaseScore;
        GameEventSystem.onIncreaseCoins += IncreaseGoldCoinsAmount;
        GameEventSystem.onIncreaseDiamonds += IncreaseDiamondsAmount;
    }
    private void OnDestroy()
    {
        GameEventSystem.onIncreaseScore -= IncreaseScore;
        GameEventSystem.onIncreaseCoins -= IncreaseGoldCoinsAmount;
        GameEventSystem.onIncreaseDiamonds -= IncreaseDiamondsAmount;
    }

    public void IncreaseScore(int score)
    {
        CurrentScore += score;
        Debug.Log("Score: " + CurrentScore);
    }
    public void IncreaseGoldCoinsAmount()
    {
        CurrentCoinsAmount++;
        Debug.Log("Gold Coins: " + CurrentCoinsAmount + "/" + _goldCoinCount);
    }
    public void IncreaseDiamondsAmount()
    {
        CurrentDiamondsAmount++;
        Debug.Log("Diamonds: " + CurrentDiamondsAmount + "/" + _diamondCount);
    }
}
