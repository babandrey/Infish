using UnityEngine;

public class OnBackgroudClicked : MonoBehaviour
{
    private FoodManager foodManager;

    void Start()
    {
        foodManager = FoodManager.Instance;
    }

    void OnMouseDown()
    {
        foodManager.SpawnFood();
    }
}
