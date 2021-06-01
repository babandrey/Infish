﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodManager : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Food[] foodPrefabList;
    private int foodsOnScreen = 0;

    [Range(1, 10)]
    [SerializeField] private int maxFoodAmount;
    private Food currentFood;
    private int currentFoodIndex = 0;

    #region Singleton

    public static FoodManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public int FoodsOnScreen
    {
        get { return foodsOnScreen; }
        set { foodsOnScreen = value; }
    }

    public int MaxFoodAmount
    {
        get { return maxFoodAmount; }
        set 
        {
            if(maxFoodAmount < 10)
            {
                maxFoodAmount = value;
            } 
        }
    }

    public int CurrentFoodIndex
    {
        get { return currentFoodIndex; }
        set 
        {
            if(value <= foodPrefabList.Length - 1)
            {
                currentFoodIndex = value;
                currentFood = foodPrefabList[currentFoodIndex];
            }
        }
    }

    void Start()
    {
        currentFood = foodPrefabList[currentFoodIndex];

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void SpawnFood()
    {
        if (FoodsOnScreen < maxFoodAmount)
        {
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            ObjectPooler.instance.SpawnFromPool(currentFood.name, position, currentFood.transform.rotation);
        }
    }
}
