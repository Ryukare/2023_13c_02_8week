using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _scoreValue;
    private int _score
    {
        get => _scoreValue;
        set
        {
            _scoreValue = value;
            PlayerEventSystem.UpdateScore(value);
        }
    }

    private int _silverCoinAmountValue;
    private int _silverCoinAmount
    {
        get => _silverCoinAmountValue;
        set
        {
            _silverCoinAmountValue = value;
            PlayerEventSystem.UpdateSilverCoinAmount(value);
        }
    }
    private int _goldCoinAmountValue;
    private int _goldCoinAmount
    {
        get => _goldCoinAmountValue;
        set
        {
            _goldCoinAmountValue = value;
            PlayerEventSystem.UpdateGoldCoinAmount(value);
        }
    }
    private int _diamondAmountValue;
    private int _diamondAmount
    {
        get => _diamondAmountValue;
        set
        {
            _diamondAmountValue = value;
            PlayerEventSystem.UpdateDiamondAmount(value);
        }
    }

    private void Awake()
    {
        PlayerEventSystem.OnScoreIncrease += IncreaseScore;
        PlayerEventSystem.OnSilverCoinCollected += IncreaseSilverCoinAmount;
        PlayerEventSystem.OnGoldCoinCollected += IncreaseGoldCoinAmount;
        PlayerEventSystem.OnDiamondCollected += IncreaseDiamondAmount;
    }
    private void Start()
    {
        _score = 0;
        _silverCoinAmount = 0;
        _goldCoinAmount = 0;
        _diamondAmount = 0;
    }

    public void OnDestroy()
    {
        PlayerEventSystem.OnScoreIncrease -= IncreaseScore;
        PlayerEventSystem.OnSilverCoinCollected -= IncreaseSilverCoinAmount;
        PlayerEventSystem.OnGoldCoinCollected -= IncreaseGoldCoinAmount;
        PlayerEventSystem.OnDiamondCollected -= IncreaseDiamondAmount;
    }

    public int GetGoldCoins()
    {
        return _goldCoinAmount;
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _score += scoreIncrease;
    }
    public void IncreaseSilverCoinAmount()
    {
        _silverCoinAmount++;
    }
    public void IncreaseGoldCoinAmount()
    {
        _goldCoinAmount++;
    }
    public void IncreaseDiamondAmount()
    {
        _diamondAmount++;
    }
}
