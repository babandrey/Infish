using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuyButtonMethods
{
    public static void SpawnFish(string tag)
    {
        ObjectPooler.instance.SpawnFromPool(tag);
        GoldManager.instance.ChangeGoldAmount(-100);
    }

    public static void UpgradeFood()
    {

    }

    public static void IncreaseFoodAmount()
    {

    }

    public static void UpgradeWeapon()
    {

    }

    public static void BuyEgg()
    {

    }
}
