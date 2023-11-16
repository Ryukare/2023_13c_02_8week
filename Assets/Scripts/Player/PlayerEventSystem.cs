using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class PlayerEventSystem
{
    public static event Action<int> OnPlayerHealthUpdate;
    public static event Action<int> OnPlayerHeal;
    public static event Action<int> OnPlayerHit;

    public static event Action<int> OnScoreUpdate;
    public static event Action<int> OnScoreIncrease;

    public static event Action<int> OnSilverCoinAmountUpdate;
    public static event Action OnSilverCoinCollected;

    public static event Action<int> OnGoldCoinAmountUpdate;
    public static event Action OnGoldCoinCollected;

    public static event Action<int> OnDiamondAmountUpdate;
    public static event Action OnDiamondCollected;

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
