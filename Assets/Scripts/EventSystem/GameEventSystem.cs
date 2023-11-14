using System;
public static class GameEventSystem
{
    public static event Action<int> onPlayerHeal;
    public static event Action<int> onPlayerHealthUpdate;

    public static event Action<int> onIncreaseScore;
    public static event Action<int> onIncreaseScoreUpdate;

    public static event Action onIncreaseCoins;
    public static event Action<int> onIncreaseCoinsUpdate;

    public static event Action onIncreaseDiamonds;
    public static event Action<int> onIncreaseDiamondsUpdate;

    public static void HealPlayer(int healAmount)
    {
        onPlayerHeal?.Invoke(healAmount);
    }
    public static void UpdatePlayerHealth(int currentHealth)
    {
        onPlayerHealthUpdate?.Invoke(currentHealth);
    }
    public static void IncreaseScore(int addScore)
    {
        onIncreaseScore?.Invoke(addScore);
    }
    public static void UpdateScore(int currentScore)
    {
        onIncreaseScoreUpdate?.Invoke(currentScore);
    }
    public static void IncreaseCoins()
    {
        onIncreaseCoins?.Invoke();
    }
    public static void UpdateCoins(int currentCoins)
    {
        onIncreaseCoinsUpdate?.Invoke(currentCoins);
    }
    public static void IncreaseDiamonds()
    {
        onIncreaseDiamonds?.Invoke();
    }
    public static void UpdateDiamonds(int currentDiamonds)
    {
        onIncreaseDiamondsUpdate?.Invoke(currentDiamonds);
    }
}