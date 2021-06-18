using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fish))]
public class GrowSize : MonoBehaviour
{
    private Fish fish;
    private DropGold dropGold;
    private ObjectPooler objectPooler;

    [SerializeField] private int maxEatAmount;
    [SerializeField] private int currentEatenAmount;
    [SerializeField] private int currentGrowTimes;
    [SerializeField] private int maxGrowTimes;

    [SerializeField] private int dropGoldSize;
    [SerializeField] private int becomeUnedibleSize;

    private void Awake()
    {
        fish = GetComponent<Fish>();
        dropGold = GetComponent<DropGold>();
        objectPooler = ObjectPooler.Instance;
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

            if (currentGrowTimes == dropGoldSize)
            {
                fish.IsDroppingGold = true;
            }

            if (fish.IsDroppingGold)
            {
                dropGold.CurrentGoldDropIndex++;
            }

            if (currentGrowTimes == becomeUnedibleSize)
            {
                objectPooler.RemoveObjectFromEdiblePool(gameObject);
            }

            LeanTween.scale(gameObject, transform.localScale * 1.4f, 1f).setEaseOutElastic();
        }
    }
}
