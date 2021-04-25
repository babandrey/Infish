using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private int goldAmount = 200;

    #region Singleton

    public static GoldManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
    }

    public void DecreaseGold(int amount)
    {
        if (goldAmount - amount > 0)
        {
            goldAmount -= amount;
        }
    }
}
