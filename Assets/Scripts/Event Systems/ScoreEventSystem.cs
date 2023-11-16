using System;

public static class ScoreEventSystem
{
    public static event Action<int> OnScoreUpdate;
    public static event Action<int> OnScoreIncrease;

    public static event Action<int> OnSilverCoinAmountUpdate;
    public static event Action OnSilverCoinCollected;

    public static event Action<int> OnGoldCoinAmountUpdate;
    public static event Action OnGoldCoinCollected;

    public static event Action<int> OnDiamondAmountUpdate;
    public static event Action OnDiamondCollected;

    public static void UpdateScore(int currentScoreAmount)
    {
        OnScoreUpdate?.Invoke(currentScoreAmount);
    }
    public static void IncreaseScore(int currentScoreAmount)
    {
        OnScoreIncrease?.Invoke(currentScoreAmount);
    }

    public static void UpdateSilverCoinAmount(int currentAmount)
    {
        OnSilverCoinAmountUpdate?.Invoke(currentAmount);
    }
    public static void CollectSilverCoin()
    {
        OnSilverCoinCollected?.Invoke();
    }

    public static void UpdateGoldCoinAmount(int currentAmount)
    {
        OnGoldCoinAmountUpdate?.Invoke(currentAmount);
    }
    public static void CollectGoldCoin()
    {
        OnGoldCoinCollected?.Invoke();
    }

    public static void UpdateDiamondAmount(int currentAmount)
    {
        OnDiamondAmountUpdate?.Invoke(currentAmount);
    }
    public static void CollectDiamond()
    {
        OnDiamondCollected?.Invoke();
    }
}