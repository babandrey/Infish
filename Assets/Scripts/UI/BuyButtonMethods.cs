using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonMethods : MonoBehaviour
{
    public void SpawnFish(string tag)
    {
        ObjectPooler.instance.SpawnFromPool(tag);
        GoldManager.instance.ChangeGoldAmount(-100);
    }

    public void UpgradeFood()
    {

    }

    public void IncreaseFoodAmount()
    {

    }

    public void UpgradeWeapon()
    {

    }

    public void BuyEgg()
    {

    }
}
