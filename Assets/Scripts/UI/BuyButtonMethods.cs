using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuyButtonMethods
{
    public static void SpawnFish(string tag)
    {
        int amount = 100;

        if(GoldManager.instance.GoldAmount >= amount)
        {
            ObjectPooler.instance.SpawnFromPool(tag);
            GoldManager.instance.DecreaseGold(amount);
        }
    }

    public static void UpgradeFood()
    {
        int amount = 300;

        if (GoldManager.instance.GoldAmount >= amount)
        {
            FoodManager.instance.CurrentFoodIndex++;
            GoldManager.instance.DecreaseGold(amount);
        }
    }

    public static void IncreaseFoodAmount()
    {
        int amount = 200;

        if (GoldManager.instance.GoldAmount >= amount)
        {
            FoodManager.instance.MaxFoodAmount++;
            GoldManager.instance.DecreaseGold(amount);
        }
    }

    public static void UpgradeWeapon()
    {

    }

    public static void BuyEgg()
    {

    }
}
