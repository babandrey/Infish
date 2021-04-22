using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private int goldAmount = 200;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }

    public void ChangeGoldAmount(int amount) 
    {
        if(goldAmount - amount > 0)
        {
            goldAmount += amount;
        }
    }
}
