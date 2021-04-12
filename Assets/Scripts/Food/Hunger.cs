using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float hungerAmount = 100f; // lower over time, once gets to 0 the fish dies
    [SerializeField] private bool isHungry = false;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(HungerTimer());
    }

    void Update()
    {
        if(hungerAmount < 50 && !isHungry)
        {
            isHungry = true;
        }
        else if(hungerAmount > 50 && isHungry)
        {
            isHungry = false;
        }
    }

    IEnumerator HungerTimer()
    {
        while (hungerAmount != 0)
        {
            hungerAmount -= 0.5f;
            yield return new WaitForSeconds(0.05f);
        }

        Destroy(gameObject);
    }

    public float HungerAmount
    {
        get
        {
            return hungerAmount;
        }
        set
        {
            if(value > 100)
            {
                hungerAmount = 100;
            }
            else
            {
                hungerAmount = value;
            }
        }
    }

    public bool IsHungry
    {
        get
        {
            return isHungry;
        }
    }
}
