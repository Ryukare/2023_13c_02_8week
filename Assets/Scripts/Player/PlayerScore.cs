using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score = 0;
    private int _silverCoinCount;
    private int _silverCoinAmount = 0;
    private int _goldCoinCount;
    public int goldCoinAmount = 0;
    private int _diamondCount;
    private int _diamondAmount = 0;

    private void Awake()
    {
        PlayerEventSystem.OnValuableCollected += IncreaseScore;
    }
    private void Start()
    {
        _silverCoinCount = GameObject.FindGameObjectsWithTag("SilverCoin").Length;
        _goldCoinCount = GameObject.FindGameObjectsWithTag("GoldCoin").Length;
        _diamondCount = GameObject.FindGameObjectsWithTag("Diamond").Length;
    }

    public void OnDestroy()
    {
        PlayerEventSystem.OnValuableCollected -= IncreaseScore;
    }

    public void IncreaseScore(string valuableName, int scoreIncrease)
    {
        _score += scoreIncrease;
        Debug.Log($"Score: {_score}");
        if (valuableName == "Silver Coin")
        {
            _silverCoinAmount++;
            Debug.Log($"Silver Coins: {_silverCoinAmount}/{_silverCoinCount}");
        }
        else if (valuableName == "Gold Coin")
        {
            goldCoinAmount++;
            Debug.Log($"Gold Coins: {goldCoinAmount}/{_goldCoinCount}");
        }
        else if (valuableName == "Diamond")
        {
            _diamondAmount++;
            Debug.Log($"Diamonds: {_diamondAmount}/{_diamondCount}");
        }
    }
}
