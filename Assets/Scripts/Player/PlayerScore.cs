using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score = 0;
    private int _allSilverCoinAmount;
    private int _playerSilverCoinAmount = 0;
    private int _allGoldCoinAmount;
    private int _playerGoldCoinAmount = 0;
    private int _allDiamondAmount;
    private int _playerDiamondAmount = 0;

    private void Awake()
    {
        PlayerEventSystem.OnValuableCollected += IncreaseScore;
    }
    private void Start()
    {
        _allSilverCoinAmount = GameObject.FindGameObjectsWithTag("SilverCoin").Length;
        _allGoldCoinAmount = GameObject.FindGameObjectsWithTag("GoldCoin").Length;
        _allDiamondAmount = GameObject.FindGameObjectsWithTag("Diamond").Length;
    }

    public void OnDestroy()
    {
        PlayerEventSystem.OnValuableCollected -= IncreaseScore;
    }

    public int GetGoldCoins()
    {
        return _playerGoldCoinAmount;
    }

    public void IncreaseScore(string valuableName, int scoreIncrease)
    {
        _score += scoreIncrease;
        Debug.Log($"Score: {_score}");
        if (valuableName == "Silver Coin")
        {
            _playerSilverCoinAmount++;
            Debug.Log($"Silver Coins: {_playerSilverCoinAmount}/{_allSilverCoinAmount}");
        }
        else if (valuableName == "Gold Coin")
        {
            _playerGoldCoinAmount++;
            Debug.Log($"Gold Coins: {_playerGoldCoinAmount}/{_allGoldCoinAmount}");
        }
        else if (valuableName == "Diamond")
        {
            _playerDiamondAmount++;
            Debug.Log($"Diamonds: {_playerDiamondAmount}/{_allDiamondAmount}");
        }
    }
}
