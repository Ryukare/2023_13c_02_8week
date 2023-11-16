using System;

public static class PlayerHealthEventSystem
{
    public static event Action<int> OnPlayerHealthUpdate;
    public static event Action<int> OnPlayerHeal;
    public static event Action<int> OnPlayerHit;

    public static void UpdatePlayerHealth(int currentHealthAmount)
    {
        OnPlayerHealthUpdate?.Invoke(currentHealthAmount);
    }
    public static void HealPlayer(int healAmount)
    {
        OnPlayerHeal?.Invoke(healAmount);
    }
    public static void HitPlayer(int damage)
    {
        OnPlayerHit?.Invoke(damage);
    }
}
