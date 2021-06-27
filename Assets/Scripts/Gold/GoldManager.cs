using System;
using UnityEngine;

public static class GoldManager
{
    [SerializeField] private static int goldAmount = 10000;
    public static Action<int> OnGoldUpdated;

    public static void AddGold(int amount)
    {
        goldAmount += amount;
        OnGoldUpdated(goldAmount);
    }

    public static void DecreaseGold(int amount)
    {
        goldAmount = goldAmount - amount >= 0 ? goldAmount - amount : goldAmount;
        OnGoldUpdated(goldAmount);
    }

    public static int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }

    public static void Reset()
    {
        goldAmount = 10000;
    }
}
