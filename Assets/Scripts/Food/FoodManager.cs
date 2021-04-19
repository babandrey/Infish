using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Food[] foodPrefabList;
    private int foodsOnScreen = 0;

    [Range(1, 10)]
    [SerializeField] private int maxFoodAmount;
    private Food currentFood;

    #region Singleton

    public static FoodManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public int FoodsOnScreen
    {
        get { return foodsOnScreen; }
        set { foodsOnScreen = value; }
    }

    void Start()
    {
        currentFood = foodPrefabList[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && FoodsOnScreen < maxFoodAmount)
        {
            if (EventSystem.current.currentSelectedGameObject == null) //checks if we pressed a button
            {
                Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;
                ObjectPooler.instance.SpawnFromPool(currentFood.name, position, currentFood.transform.rotation);
            }
        }
    }

    
}
