using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fish))]
public class GrowSize : MonoBehaviour
{
    private Fish fish;
    private ObjectPooler objectPooler;

    [SerializeField] private int maxEatAmount;
    [SerializeField] private int currentEatenAmount;
    [SerializeField] private int currentGrowTimes;
    [SerializeField] private int maxGrowTimes;

    private void Awake()
    {
        fish = GetComponent<Fish>();
        objectPooler = ObjectPooler.instance;
    }

    public void OnEatFood(int nutritionalValue)
    {
        currentEatenAmount += nutritionalValue;

        if (maxEatAmount > currentEatenAmount)
        {
            return;
        }

        if (maxGrowTimes > currentGrowTimes)
        {
            currentGrowTimes++;
            currentEatenAmount = 0;

            if (currentGrowTimes == 1)
            {
                ObjectPooler.instance.RemoveObjectFromEdiblePool(gameObject);
            }

            LeanTween.scale(gameObject, transform.localScale * 1.4f, 1f).setEaseOutElastic();
        }
    }
}
