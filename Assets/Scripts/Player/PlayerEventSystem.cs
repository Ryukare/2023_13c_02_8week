using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class PlayerEventSystem
{
    public static event Action<int> OnPlayerHeal;
    public static event Action<string, int> OnValuableCollected;
    public static event Action<int> OnPlayerHit;

    public static void HealPlayer(int healAmount)
    {
        OnPlayerHeal?.Invoke(healAmount);
    }
    public static void CollectValuable(string valuableName, int scoreIncrease)
    {
        OnValuableCollected?.Invoke(valuableName, scoreIncrease);
    }
    public static void HitPlayer(int damage)
    {
        OnPlayerHit?.Invoke(damage);
    }
}
