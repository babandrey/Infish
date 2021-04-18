using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Food[] foodPrefabList;
    public int FoodsOnScreen { get; set; } = 0;

    [Range(1, 10)]
    [SerializeField] private int maxFoodAmount = 1;
    private Food currentFood;

    #region Singleton

    public static FoodManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    // Start is called before the first frame update
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
                GameObject foodSpawned = ObjectPooler.instance.SpawnFromPool(currentFood.name, position, currentFood.transform.rotation);
            }
        }
    }

    
}
