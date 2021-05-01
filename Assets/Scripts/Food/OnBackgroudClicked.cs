using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBackgroudClicked : MonoBehaviour
{
    private FoodManager foodManager;

    void Start()
    {
        foodManager = FoodManager.instance;
    }

    void OnMouseDown()
    {
        foodManager.SpawnFood();
    }
}
