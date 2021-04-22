using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonMethods : MonoBehaviour
{
    public void SpawnFish(string tag)
    {
        ObjectPooler.instance.SpawnFromPool(tag);
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
